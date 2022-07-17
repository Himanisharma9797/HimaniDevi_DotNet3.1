using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Service.DAL.AmountDb
{
    public class AmountDbContext : DbContext
    {
        #region Public DbContext
        public AmountDbContext(DbContextOptions<AmountDbContext> options)
           : base(options)
        {
        }
        #endregion
        #region DbSets
        public DbSet<Amount> Amounts { get; set; }
        #endregion
    }
}
