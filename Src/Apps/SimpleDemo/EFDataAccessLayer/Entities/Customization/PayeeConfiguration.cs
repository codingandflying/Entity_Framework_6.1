using System.Data.Entity.ModelConfiguration;

namespace EFDataAccessLayer.Entities.Configuration
{
    /// <summary>
    /// Used to configure payee table using fluent API during db model creation.
    /// </summary>
    class PayeeConfiguration : EntityTypeConfiguration<Payee>
    {
        public PayeeConfiguration()
        {
            HasKey(p => p.ID);
            Property(p => p.Name).IsRequired().HasMaxLength(Settings.Default.MediumStringLength);

            HasMany(p => p.PhoneNumbers).WithOptional().Map(m => m.MapKey("PayeeID")).WillCascadeOnDelete();

            Property(p => p.Email).IsOptional().HasMaxLength(Settings.Default.MediumStringLength);
            Property(p => p.Website).IsOptional().HasMaxLength(Settings.Default.MediumStringLength);
            Property(p => p.Memo).IsOptional().HasMaxLength(Settings.Default.LongStringLength);
        }
    }
}
