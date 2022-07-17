using Billing.Service.API.Amount;
using Billing.Service.DAL.AmountDb;
using Billing.Service.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Billing.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Billing : ControllerBase
    {
        #region Private readonly property
        private readonly AmountDbContext _amountDbContext;
        #endregion
        #region Constructor
        public Billing(AmountDbContext amountDbContext)
        {
            _amountDbContext = amountDbContext;

        }
        #endregion
        #region Public Methods
        /// <summary>
        ///  Calculate Amount
        /// </summary>
        /// <param name="TaskId"></param>
        /// <param name="Category"></param>
        /// <param name="CompletedHours"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>

        [HttpPost("CalculateAmount")]
        public ActionResult<CalculateAmountResponse> CalculateAmount(int TaskId, string Category,double CompletedHours, int UserId)
        {
            try
            { 

                var amountLogic = new AmountLogic(_amountDbContext);
                return amountLogic.GetCalculatedAmount(new CalculateAmountRequest { TaskID=TaskId, Category=Category, CompletedHours=CompletedHours ,UserId=UserId});      

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
        }
       
        /// <summary>
        ///   GET BILLING dETAILS      
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        [HttpPost("BillingDetails")]
        public ActionResult<GetBillingDetailsResponse> GetBillingDetails(int TaskId)
        {
            try
            {
                var amountLogic = new AmountLogic(_amountDbContext);
                return amountLogic.GetBillingInfo(new RecordRequest {TaskId= TaskId});
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
        }
        /// <summary>
        /// Billing Details by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("BillingDetailsByUserID")]
        public ActionResult<BillingDetailsByUserIDResponse> BillingDetailsByUserID(int userId)
        {
            try
            {
                var amountLogic = new AmountLogic(_amountDbContext);
                return amountLogic.GetBillingDetails(new RecordRequestByUserId { UserId= userId });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
        }


    }
    #endregion
}
