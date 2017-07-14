using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataAccessLayer.Entities.Configuration
{
    /// <summary>
    /// Used to configure categories table using fluent API during db model creation.
    /// </summary>
    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(Settings.Default.ShortStringLength);

            HasOptional(c => c.ParentCategory).WithMany(c => c.SubCategories).Map(m => m.MapKey("ParentID")).WillCascadeOnDelete(false);

            Property(c => c.IsMainCategory).IsRequired();
            Property(c => c.Comment).IsOptional().HasMaxLength(Settings.Default.LongStringLength);
        }
    }
}
