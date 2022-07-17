using Billing.Service.API.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Billing.Service.API.Common.BaseDTO;
using static Billing.Service.API.Common.ResponseResult;

namespace Billing.Service.API.Amount
{
    #region RecordInfo
    public class RecordInfo
    {
        public int TaskId { get; set; }
    }
    #endregion
    #region RecordInfoByUserId
    public class RecordInfoByUserId
    {
        public double TotalBillCalculated { get; set; }
        public DateTime BilledOn { get; set; }
    }
    #endregion
}
