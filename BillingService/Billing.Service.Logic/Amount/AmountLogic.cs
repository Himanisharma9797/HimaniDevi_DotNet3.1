using Billing.Service.API.Amount;
using Billing.Service.API.Common;
using Billing.Service.DAL.AmountDb;

using Billing.Service.Logic.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using static Billing.Service.API.Common.BaseDTO;
using static Billing.Service.API.Common.ResponseResult;


namespace Billing.Service.Logic
{
    public class AmountLogic
    {
        #region Private readonly property
        private readonly AmountDbContext _amountDbContext;
        #endregion
        #region Constructor
        public AmountLogic(AmountDbContext amountDbContext )
        {
            _amountDbContext = amountDbContext;
        
        }
        #endregion
       
        #region Public Methods
        public CalculateAmountResponse GetCalculatedAmount(CalculateAmountRequest request)
        {
           
            var response = new CalculateAmountResponse();

            try
            {
                Validation.RequiredParameter("Request", request);
                Validation.RequiredParameter("TaskId", request.TaskID);
               Validation.RequiredIntParameter("TaskId", request.TaskID);
                Validation.RequiredParameter("CompletedHours", request.CompletedHours);
                Validation.RequiredDoubleParameter("CompletedHours", request.CompletedHours);
                Validation.RequiredParameter("Category", request.Category);
           

                int PerHour = 50;
                var calcCategory = Enum.Parse(typeof(CategoryResult),request.Category.ToLower());
                response.TotalAmountCalculated = PerHour * (request.CompletedHours) * (int)calcCategory;
                _amountDbContext.Amounts.Add(new Amount
                {
                 
                    TotalBillCalculated = response.TotalAmountCalculated,
                    BilledOn= DateTime.Now,                    
                    TaskId = request.TaskID,
                     UserId=request.UserId              

                });
                _amountDbContext.SaveChanges();                
            }

            catch (Exception ex)
            {
                
                ex.Data.Add("Request", request);            
                response.ResponseResult = ResponseResultEnum.Warning.ToString();
                return ExceptionHelpers.ProcessException<CalculateAmountResponse>(request, ex);
            }

            return new CalculateAmountResponse
            {
                TotalAmountCalculated = response.TotalAmountCalculated,
                 BilledOn=response.BilledOn,
                ResponseResult = ResponseResultEnum.Success.ToString(),
                ResponseMessage = "Amount calculated successfully",

            };

        }    
        public GetBillingDetailsResponse GetBillingInfo(RecordRequest request)
        {
            Validation.RequiredParameter("Request", request);
            Validation.RequiredParameter("TaskId", request.TaskId);
            Validation.RequiredIntParameter("TaskId", request.TaskId);
            try
            {
                var amountInfo = _amountDbContext.Amounts.FirstOrDefault(x => x.TaskId == request.TaskId);
                if (amountInfo != null)
                {
                    return new GetBillingDetailsResponse()
                    {
                        BillingId = amountInfo.BillingId,
                        TotalAmountCalculated = amountInfo.TotalBillCalculated,
                        BilledOn = amountInfo.BilledOn,
                        ResponseResult = ResponseResultEnum.Success.ToString(),
                        ResponseMessage = "Billing details Found"
                    };
                }
                return new GetBillingDetailsResponse()
                {
                    ResponseResult = ResponseResultEnum.Warning.ToString(),
                     ResponseMessage = "Billing details not found."

                };

            }
            catch (Exception ex)
            {
                ex.Data.Add("TaskId", request.TaskId);
                return ExceptionHelpers.ProcessException<GetBillingDetailsResponse>( request,ex);
            }
        }
        public BillingDetailsByUserIDResponse GetBillingDetails (RecordRequestByUserId request)
        {
            try
            {
                Validation.RequiredParameter("Request", request);
                Validation.RequiredParameter("UserId", request.UserId);
                Validation.RequiredIntParameter("UserId", request.UserId);

                var billingInfo = _amountDbContext.Amounts.Where(x => x.UserId == request.UserId).ToList();

                if (billingInfo == null || billingInfo.Count == 0)
                {
                    return new BillingDetailsByUserIDResponse
                    {
                        ResponseMessage = "Billing details not found for the entered userId",
                        ResponseResult = ResponseResultEnum.Warning.ToString()
                    };
                }
                else
                {
                    var info = JsonConvert.DeserializeObject<List<RecordInfoByUserId>>(JsonConvert.SerializeObject(billingInfo));

                    return new BillingDetailsByUserIDResponse
                    {
                        TaskDetailsByUserID = info,
                         ResponseMessage="Billing details found",
                           ResponseResult=ResponseResultEnum.Success.ToString()

                    };
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("UserId", request.UserId);
                return ExceptionHelpers.ProcessException<BillingDetailsByUserIDResponse>(request, ex);
            }
        }
        #endregion

    }

}




