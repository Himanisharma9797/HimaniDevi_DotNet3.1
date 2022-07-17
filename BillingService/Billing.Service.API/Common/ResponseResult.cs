using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Billing.Service.API.Common
{
   public class ResponseResult
    {
        #region ResponseResultEnum
        public enum ResponseResultEnum
        {
            Success,
            Warning,
            Exception,
            ServiceFault
        }
        #endregion

    }

}
