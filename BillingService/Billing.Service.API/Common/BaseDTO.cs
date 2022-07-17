using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Service.API.Common
{
    public class BaseDTO
    {
        #region RequestBase
        public class RequestBase
        {
        }
        #endregion
        #region ResponseBase
        public class ResponseBase
        {
            public string ResponseResult { get; set; }
            public string ResponseMessage { get; set; }

        }
        #endregion
    }
}

