using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace TPC
{
    public class InheritanceMappingContextTPC : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingDetail>()
            .Property(p => p.BillingDetailId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<BankAccount>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BankAccounts");
            });

            modelBuilder.Entity<CreditCard>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CreditCards");
            });
        }
    }
}