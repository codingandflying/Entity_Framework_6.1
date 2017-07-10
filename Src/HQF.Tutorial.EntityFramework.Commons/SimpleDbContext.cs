using System.Data.Entity;
using Entities;

namespace HQF.Tutorial.EntityFramework.Commons
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
