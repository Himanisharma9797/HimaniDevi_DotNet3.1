using Billing.Service.API.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Billing.Service.API.Common.BaseDTO;
using static Billing.Service.API.Common.ResponseResult;

namespace Billing.Service.Logic.Common
{
    public class ExceptionHelpers
    {
        public async static Task<string> ProcessException(Exception ex)
        {

            var _calculateRequest = new Billing.Service.API.Amount.CalculateAmountRequest()
            {
                 //Category = new Billing.Service.API.Amount.CalculateAmountInfo()

            };

            var _ClientErrorMessage = ex.Message;
           //_calculateRequest.calculateAmountInfo.TaskID = Int32.Parse(  _ClientErrorMessage);
            try
            {
                //_calculateRequest.calculateAmountInfo.TaskID =Int32.Parse( ex.Message);

            }
            catch
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }

            return _ClientErrorMessage;
        }
        public static T ProcessException<T>(
          RequestBase Request, Exception ex) where T : ResponseBase
        {
            var _Response = Activator.CreateInstance<T>();

            if (ex is ValidationException)
                _Response.ResponseResult = nameof(ResponseResult.ResponseResultEnum.Warning);

            else
                _Response.ResponseResult = nameof(ResponseResult.ResponseResultEnum.ServiceFault);

            var _errMsg = ProcessException(ex);

            _Response.ResponseMessage = _errMsg.Result;

            return _Response;
        }


    }
}

