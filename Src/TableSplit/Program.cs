using System;
using System.Linq;
using TableSplit.Entities;

//Please Reference the article for more Detail.
//http://weblogs.asp.net/manavi/associations-in-ef-4-1-code-first-part-4-table-splitting
namespace TableSplit
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                var employee = new Employee()
                {
                    FirstName = "Frank",
                    LastName = "Huo",
                    EmployeePhoto = new EmployeePhoto() { PhotoPath = @"D:\face.ico" }
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                employee = context.Employees.First();
                byte[] photo = employee.EmployeePhoto.Photo;

                Console.Read();
            }
        }
    }
}