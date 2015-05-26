using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Entities;
using TPC;
using TPH;
using TPT;

namespace ConsoleEFHierachy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TestTPH();

            //TestTPT();

            TestTPC();
        }

        private static void TestTPC()
        {
            using (var context = new InheritanceMappingContextTPC())
            {
                //BankAccount bankAccount = new BankAccount();
                //CreditCard creditCard = new CreditCard() { CardType = 1 };


                var bankAccount = new BankAccount()
                {
                    BillingDetailId = 1
                };
                var creditCard = new CreditCard()
                {
                    BillingDetailId = 2,
                    CardType = 1
                };

                context.BillingDetails.Add(bankAccount);
                context.BillingDetails.Add(creditCard);

                var query = from b in context.BillingDetails select b;
                query.ToList();

                context.SaveChanges();
            }
        }

        private static void TestTPT()
        {
            using (var context = new InheritanceMappingContextTPT())
            {
                CreditCard creditCard = new CreditCard()
                {
                    Number = "987654321",
                    CardType = 1
                };
                User user = new User()
                {
                    UserId = 1,
                    BillingInfo = creditCard
                };
                context.Users.Add(user);
                context.SaveChanges();

                user = context.Users.Find(1);
                Debug.Assert(user.BillingInfo is CreditCard);

                var query = from b in context.BillingDetails.OfType<BankAccount>() select b;

                query.ToList();

                var query2 = from b in context.BillingDetails select b;
                query2.ToList();
            }
        }

        private static void TestTPH()
        {
            using (var context = new InheritanceMappingContextTPH())
            {
                var bankAccount = new BankAccount() { BankName = "EBank", Number = "4162", Owner = "Frank" };
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