using System.Data.Entity;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace TPH
{
    public class InheritanceMappingContextTPH : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }

        /// <summary>
        /// Change Discriminator Column Data Type and Values With Fluent API 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BillingDetail>()
            //            .Map<BankAccount>(m => m.Requires("BillingDetailType").HasValue("BA"))
            //            .Map<CreditCard>(m => m.Requires("BillingDetailType").HasValue("CC"));

            modelBuilder.Entity<BillingDetail>()
            .Map<BankAccount>(m => m.Requires("BillingDetailType").HasValue(1))
            .Map<CreditCard>(m => m.Requires("BillingDetailType").HasValue(2));
        }


    }
}