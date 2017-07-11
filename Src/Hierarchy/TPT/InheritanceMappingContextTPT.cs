using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace TPT
{
    public class InheritanceMappingContextTPT:DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }

        public DbSet<User> Users { get; set; }

        //we also can using [Table()]..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");
        }

    }
}
