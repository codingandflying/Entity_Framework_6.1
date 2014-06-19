using System.Data.Entity.ModelConfiguration;

namespace EFDataAccessLayer.Entities.Configuration
{
    /// <summary>
    /// Used to configure phonenumbers table using fluent API during db model creation.
    /// </summary>
    class PhoneNumberConfiguration : EntityTypeConfiguration<PhoneNumber>
    {
        public PhoneNumberConfiguration()
        {
            HasKey(n => n.ID);
            Property(n => n.Number).IsRequired().HasMaxLength(Settings.Default.ShortStringLength);
            Property(n => n.Description).IsRequired().HasMaxLength(Settings.Default.ShortStringLength);
        }
    }
}
