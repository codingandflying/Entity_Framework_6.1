using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableSplit.Entities;

namespace TableSplit
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePhoto> EmployeePhoto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.EmployeePhoto)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<EmployeePhoto>().ToTable("Employees");

        }
    }
}
