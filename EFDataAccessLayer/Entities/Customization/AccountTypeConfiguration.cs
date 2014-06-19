using System.Data.Entity.ModelConfiguration;

namespace EFDataAccessLayer.Entities.Configuration
{
    /// <summary>
    /// Used to configure account types table using fluent API during db model creation.
    /// </summary>
    class AccountTypeConfiguration : EntityTypeConfiguration<AccountType>
    {
        public AccountTypeConfiguration()
        {
            HasKey(t => t.ID);
            Property(t => t.TypeName).IsRequired().HasMaxLength(Settings.Default.ShortStringLength);
            Property(t => t.CanBeNegative).IsRequired();
            HasMany(t => t.Accounts).WithRequired(a => a.AccountType).Map(m => m.MapKey("TypeID")).WillCascadeOnDelete(true);
        }
    }
}