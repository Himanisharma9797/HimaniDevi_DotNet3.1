using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Billing.Service.DAL.AmountDb
{
    #region Amount
    public class Amount
    {
        [Key]
        public int BillingId { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public double TotalBillCalculated { get; set; }
        [Required]
        public DateTime BilledOn { get; set; }
       
    }
    #endregion
}
