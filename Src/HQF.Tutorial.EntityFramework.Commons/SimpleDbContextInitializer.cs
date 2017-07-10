using System.Data.Entity;
using Entities;

namespace HQF.Tutorial.EntityFramework.Commons
{
    public class SimpleDbContextInitializer : CreateDatabaseIfNotExists<SimpleDbContext>
    {
        protected override void Seed(SimpleDbContext context)
        {
            //base.Seed(context);

            context.Categories.Add(new Category() {Name= "Book"});
            context.Categories.Add(new Category() {Name = "Music"});

            context.SaveChanges();
        }
    }
}