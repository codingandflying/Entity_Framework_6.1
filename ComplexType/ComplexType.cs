using System.Data.Entity;
using ComplexType.Entities;

namespace ComplexType
{
    public class ComplexType : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}