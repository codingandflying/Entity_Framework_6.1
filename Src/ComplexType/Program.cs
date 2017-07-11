using System;
using System.Linq;
using ComplexType.Entities;

namespace HQF.Tutorial.EntityFramework.ComplexTypes
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new HQF.Tutorial.EntityFramework.ComplexTypes.ComplexTypeDbContext())
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

                //user state manage.
                user = context.Users.Find(1);

                Address originalValues = context.Entry(user)
                                                .ComplexProperty(u => u.Address)
                                                .OriginalValue;

                Address currentValues = context.Entry(user)
                                               .ComplexProperty(u => u.Address)
                                               .CurrentValue;

                Console.Read();
            }
        }
    }
}