using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Billing.Service.API.Common.BaseDTO;

namespace Billing.Service.API.Amount
{
    #region CalculateAmountRequest
    public class CalculateAmountRequest : RequestBase
    {
        public int TaskID { get; set; }
        public double CompletedHours { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
    }
    #endregion
    #region RecordRequest
    public class RecordRequest : RequestBase
    {
       public int TaskId { get; set; }
    }
    #endregion
    #region CalculateAmountResponse
    public class CalculateAmountResponse : ResponseBase
    {
        public Double TotalAmountCalculated { get; set; }
        public DateTime BilledOn { get; set; } = DateTime.Now;
         
    }
    #endregion
    #region RecordResponse
    public class GetBillingDetailsResponse : ResponseBase
    {
        public int BillingId { get; set; }
        public double TotalAmountCalculated { get; set; }
        public DateTime BilledOn { get; set; }     
    }
    #endregion
    #region RecordRequestByUserId
    public class RecordRequestByUserId : RequestBase
    {
        public int UserId { get; set; }
    }
    #endregion
    #region RecordResponseByUserId
    public class BillingDetailsByUserIDResponse : ResponseBase
    {
        public List<RecordInfoByUserId> TaskDetailsByUserID { get; set; }
    }
    #endregion

}
