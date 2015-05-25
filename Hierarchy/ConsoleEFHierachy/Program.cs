using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using TPH;

namespace ConsoleEFHierachy
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTPH();
        }

        private static void TestTPH()
        {
            using (var context = new InheritanceMappingContextTPH())
            {
                var bankAccount = new BankAccount() {BankName = "EBank", Number = "4162", Owner = "Frank"};
                context.BillingDetails.Add(bankAccount);

                var creditAccount = new CreditCard()
                {
                    CardType = 1,
                    ExpiryMonth = "08",
                    ExpiryYear = "20",
                    Number = "4321",
                    Owner = "Peter"
                };
                context.BillingDetails.Add(creditAccount);

                context.SaveChanges();

                //Polymorphic Queries
                IQueryable<BillingDetail> linqQuery = from b in context.BillingDetails select b;
                List<BillingDetail> billingDetails = linqQuery.ToList();


                //Non-polymorphic Queries
                IQueryable<BankAccount> query = from b in context.BillingDetails.OfType<BankAccount>()
                    select b;
                var accountList = query.ToList();
                // EntitySQL the same as before linq
                //string eSqlQuery = @"SELECT VAlUE b FROM OFTYPE(BillingDetails, Model.BankAccount) AS b";
                //Or
                //string eSqlQuery = @"SELECT VAlUE TREAT(b as Model.BankAccount) 
                //     FROM BillingDetails AS b 
                //     WHERE b IS OF(Model.BankAccount)";

                Console.Read();
            }
        }
    }
}
