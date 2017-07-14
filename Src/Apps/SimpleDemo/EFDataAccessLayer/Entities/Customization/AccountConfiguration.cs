using System.Data.Entity.ModelConfiguration;

namespace EFDataAccessLayer.Entities.Configuration
{
    /// <summary>
    /// Class used to configure accounts table using fluent API during db model creation.
    /// </summary>
    class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.Name).IsRequired().HasMaxLength(Settings.Default.MediumStringLength);
            Property(a => a.Bank).IsOptional().HasMaxLength(Settings.Default.MediumStringLength);
            Property(a => a.AccountNo).IsOptional().HasMaxLength(Settings.Default.ShortStringLength);

            HasRequired(a => a.AccountType);
            
            Property(a => a.IsActive).IsRequired();
            Property(a => a.Currency).IsRequired().HasMaxLength(Settings.Default.ShortStringLength);
            Property(a => a.CurrencySymbol).IsRequired().IsFixedLength().HasMaxLength(3);
            Property(a => a.OpeningDate).IsOptional();
            Property(a => a.ClosingDate).IsOptional();
            Property(a => a.OpeningBalance).IsRequired().HasColumnType("numeric").HasPrecision(Settings.Default.NumericPrecision, Settings.Default.NumericScale);
            Property(a => a.CurrentBalance).IsRequired().HasColumnType("numeric").HasPrecision(Settings.Default.NumericPrecision, Settings.Default.NumericScale);
            Property(a => a.LimitBalance).IsOptional().HasColumnType("numeric").HasPrecision(Settings.Default.NumericPrecision, Settings.Default.NumericScale);
            Property(a => a.Comment).IsOptional().HasMaxLength(Settings.Default.LongStringLength);
        }
    }
}
