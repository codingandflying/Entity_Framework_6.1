using System.Data.Entity;
using ComplexType.Entities;

namespace HQF.Tutorial.EntityFramework.ComplexTypes
{
    public class ComplexTypeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                   .Property(c => c.Address.Street)
                   .HasColumnName("User_Street");
        }


    }
}