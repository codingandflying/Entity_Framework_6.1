using System;
using System.Linq;
using ComplexType.Entities;

namespace ComplexType
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new ComplexType())
            {
                var user = new User
                {
                    FirstName = "Frank",
                    LastName = "Huo",
                    Address = new Address()
                };
                context.Users.Add(user);
                context.SaveChanges();

                var query = from u in context.Users
                            select u;
                query.ToList();

                Console.Read();
            }
        }
    }
}