using System.Data.Entity.ModelConfiguration;

namespace EFDataAccessLayer.Entities.Configuration
{
    class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            HasKey(t => t.ID);
            Property(t => t.Date).IsRequired();

            HasRequired(t => t.Account).WithMany().Map(m => m.MapKey("AccountID"));

            HasRequired(t => t.OtherParty).WithMany().Map(m => m.MapKey("PayeeID"));

            Property(t => t.Amount).IsRequired();
            Property(t => t.IsTransfer).IsRequired();

            HasRequired(t => t.Category).WithMany().Map(m => m.MapKey("CategoryID"));

            Property(t => t.Notes).IsOptional().HasMaxLength(Settings.Default.MediumStringLength);

            HasOptional(t => t.ReceivingAccount).WithOptionalDependent().Map(m => m.MapKey("ReceivingAccountID"));
        }
    }
}
