using System.Data.Entity;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace HQF.Tutorial.EntityFramework.Commons.DbContexts
{
    public class SimpleDbContext:DbContext
    {

        public SimpleDbContext()
        {
            Database.SetInitializer<SimpleDbContext>(new SimpleDbContextInitializer());
        }

        public DbSet<Category> Categories { get; set; }

    }


}
