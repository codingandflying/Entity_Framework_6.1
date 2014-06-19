using EFDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFDataAccessLayer.Model
{
    class EFDbContextDebugInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            //_________________________________________________________________________________________
            #region Dummy Account Types

            var accountTypes = new List<AccountType>
            {
                new AccountType { CanBeNegative = false, TypeName = "Checking" },
                new AccountType { CanBeNegative = false, TypeName = "Savings" },
                new AccountType { CanBeNegative = true, TypeName = "Credit" }
           };

            context.AccountTypes.AddRange(accountTypes);
            context.SaveChanges();

            #endregion

            //_________________________________________________________________________________________
            #region Dummy Accounts

            var accounts = new List<Account>
            {
                new Account
                {
                    Name = "Primary Checking",
                    Bank = "Dummy Bank",
                    AccountNo = "CH-001",
                    AccountType = accountTypes.Find( a => a.TypeName == "Checking"),
                    IsActive = true,
                    Currency = "US Dollars",
                    CurrencySymbol = "USD",
                    OpeningDate = new DateTime(2014, 01, 01),
                    OpeningBalance = 1000,
                    CurrentBalance = 1000,
                    Comment = "Dummy Checking Account"
                },
                new Account
                {
                    Name = "Work Checking",
                    Bank = "Dummy Bank",
                    AccountNo = "095-4879854",
                    AccountType = accountTypes.Find( a => a.TypeName == "Checking"),
                    IsActive = true,
                    Currency = "US Dollars",
                    CurrencySymbol = "USD",
                    OpeningDate = new DateTime(2008, 10, 08),
                    OpeningBalance = 0,
                    CurrentBalance = 79542,
                    Comment = "Work Checking Account"
                },
                new Account
                {
                    Name = "Primary Savings",
                    Bank = "Piggy Bank",
                    AccountNo = "12345-6789",
                    AccountType = accountTypes.Find( a => a.TypeName == "Savings"),
                    IsActive = true,
                    Currency = "Canadian Dollars",
                    CurrencySymbol = "CAD",
                    OpeningDate = new DateTime(2014, 02, 02),
                    OpeningBalance = 25000,
                    CurrentBalance = 157846,
                    Comment = "Dummy Savings Account"
                },
                new Account
                {
                    Name = "Rainy Day Savings",
                    Bank = "Piggy Bank",
                    AccountNo = "5824685-9538742",
                    AccountType = accountTypes.Find( a => a.TypeName == "Savings"),
                    IsActive = true,
                    Currency = "US Dollars",
                    CurrencySymbol = "USD",
                    OpeningDate = new DateTime(2014, 02, 02),
                    OpeningBalance = 2000,
                    CurrentBalance = 2000,
                    Comment = "Rainy Day Savings Account"
                },
                new Account
                {
                    Name = "Premium Credit Card",
                    Bank = "Payday Bank",
                    AccountNo = "00011000",
                    AccountType = accountTypes.Find( a => a.TypeName == "Credit"),
                    IsActive = true,
                    Currency = "Australian Dollars",
                    CurrencySymbol = "AUD",
                    OpeningDate = new DateTime(2014, 03, 03),
                    OpeningBalance = 0,
                    CurrentBalance = -3000,
                    LimitBalance = -5000,
                    Comment = "Dummy Credit Account"
                },
                new Account
                {
                    Name = "Home Mortgage",
                    Bank = "Mortgage Bank",
                    AccountNo = "99857456",
                    AccountType = accountTypes.Find( a => a.TypeName == "Credit"),
                    IsActive = true,
                    Currency = "Canadian Dollars",
                    CurrencySymbol = "CAD",
                    OpeningDate = new DateTime(2001, 06, 10),
                    OpeningBalance = -200000,
                    CurrentBalance = -35000,
                    LimitBalance = -200000,
                    Comment = "Home Mortgage Account"
                }
            };

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            #endregion

            //_________________________________________________________________________________________
            #region Dummy Categories

            var categories = new List<Category>
            {
            new Category { Name = "Grocery", IsMainCategory = true },
            new Category { Name = "Entartainment", IsMainCategory = true },
            new Category { Name = "Household", IsMainCategory = true },
            new Category { Name = "Bills", IsMainCategory = true }
            };

            var subCategories = new List<Category>
            {
                new Category { Name = "Food", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Grocery" ) },
                new Category { Name = "Beverage", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Grocery" ) },
                new Category { Name = "Dining out", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Entartainment" ) },
                new Category { Name = "Repairs", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Household" ) },
                new Category { Name = "Furniture", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Household" ) },
                new Category { Name = "Cable", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Bills" ) },
                new Category { Name = "Water", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Bills" ) },
                new Category { Name = "Phone", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Bills" ) },
                new Category { Name = "Electricity", IsMainCategory = true, ParentCategory = categories.Find( c => c.Name == "Bills" ) }
            };

            categories.AddRange(subCategories);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            #endregion

            //_________________________________________________________________________________________
            #region Dummy Payees

            var payees = new List<Payee>
            {
                new Payee
                {
                    Name = "A Food Store",
                    Address = new Address
                    {
                        Street = "123 Main St.",
                        City = "Cityville",
                        State = "Stateside",
                        ZipCode = "12345",
                        Country = "USA"
                    },
                    Email = "contact@afoodstore.com",
                    PhoneNumbers = new List<PhoneNumber>
                    { 
                        new PhoneNumber { Description="Office", Number="123-456-7890"},
                        new PhoneNumber { Description="Home", Number="123-456-7890"},
                        new PhoneNumber { Description="Mobile", Number="123-456-7890"},
                    },
                    Website = "www.afoodstore.com",
                    Memo = "Great Store, fresh fruits"
                },
                new Payee
                {
                    Name = "Home Goods Store",
                    Address = new Address
                    {
                        Street = "456 Second St.",
                        City = "Cityville",
                        State = "Stateside",
                        ZipCode = "22335",
                        Country = "USA"
                    },
                    Email = "homer@homegoodsstore.com",
                    PhoneNumbers = new List<PhoneNumber>
                    { 
                        new PhoneNumber { Description="Office", Number="123-456-7890"},
                        new PhoneNumber { Description="Home", Number="758-456-5478"},
                        new PhoneNumber { Description="Mobile", Number="857-488-2014"},
                    },
                    Website = "www.homegoodsstore.com",
                    Memo = "Lots of variety"
                },
                new Payee
                {
                    Name = "Magic Diner",
                    Address = new Address
                    {
                        Street = "7890 Third Ave.",
                        City = "Northridge",
                        State = "Farstate",
                        ZipCode = "658424",
                        Country = "USA"
                    },
                    Email = "joe@magicdiner.com",
                    PhoneNumbers = new List<PhoneNumber>
                    { 
                        new PhoneNumber { Description="Office", Number="457-547-7541"},
                        new PhoneNumber { Description="Home", Number="857-412-2578"},
                        new PhoneNumber { Description="Mobile", Number="123-854-4158"},
                    },
                    Website = "www.homegoodsstore.com",
                    Memo = "Delicious, been there on last anniversary"
                },
                new Payee
                {
                    Name = "All Utilities Company",
                    Address = new Address
                    {
                        Street = "58425 Powerline Ct.",
                        City = "Nuketown",
                        State = "Coalville",
                        ZipCode = "95875",
                        Country = "USA"
                    },
                    Email = "powerr@allutilitiescorp.com",
                    PhoneNumbers = new List<PhoneNumber>
                    { 
                        new PhoneNumber { Description="Office", Number="457-953-8547"},
                        new PhoneNumber { Description="Home", Number="758-9652-7841"},
                        new PhoneNumber { Description="Mobile", Number="857-487-6201"},
                    },
                    Website = "www.homegoodsstore.com",
                    Memo = "Delicious, been there on last anniversary"
                },

            };

            context.Payees.AddRange(payees);
            context.SaveChanges();

            #endregion

            //_________________________________________________________________________________________
            #region Dummy Transactions

            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(3),
                    Account = accounts.Find( a => a.Name == "Primary Checking"),
                    Amount = 55,
                    Category = categories.Find(c => c.Name == "Food"),
                    OtherParty = payees.Find(p => p.Name == "A Food Store"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today,
                    Account = accounts.Find(a => a.Name == "Primary Savings"),
                    Amount = 70,
                    Category = categories.Find(c => c.Name == "Dining out"),
                    OtherParty = payees.Find(p => p.Name == "Magic Diner"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(322),
                    Account = accounts.Find( a => a.Name == "Premium Credit Card"),
                    Amount = 120,
                    Category = categories.Find(c => c.Name == "Cable"),
                    OtherParty = payees.Find(p => p.Name == "All Utilities Company"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(66),
                    Account = accounts.Find(a => a.Name == "Premium Credit Card"),
                    Amount = 110,
                    Category = categories.Find(c => c.Name == "Water"),
                    OtherParty = payees.Find(p => p.Name == "All Utilities Company"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(24),
                    Account = accounts.Find(a => a.Name == "Primary Savings"),
                    Amount = 350,
                    Category = categories.Find(c => c.Name == "Electricity"),
                    OtherParty = payees.Find(p => p.Name == "All Utilities Company"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(13),
                    Account = accounts.Find( a => a.Name == "Premium Credit Card"),
                    Amount = 30,
                    Category = categories.Find(c => c.Name == "Food"),
                    OtherParty = payees.Find(p => p.Name == "A Food Store"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(25),
                    Account = accounts.Find(a => a.Name == "Primary Checking"),
                    Amount = 77,
                    Category = categories.Find(c => c.Name == "Repairs"),
                    OtherParty = payees.Find(p => p.Name == "Home Goods Store"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(5),
                    Account = accounts.Find(a => a.Name == "Primary Savings"),
                    Amount = 45,
                    Category = categories.Find(c => c.Name == "Bills"),
                    OtherParty = payees.Find(p => p.Name == "All Utilities Company"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(6),
                    Account = accounts.Find( a => a.Name == "Premium Credit Card"),
                    Amount = 10,
                    Category = categories.Find(c => c.Name == "Food"),
                    OtherParty = payees.Find(p => p.Name == "A Food Store"),
                    IsTransfer = false
                },
                new Transaction
                {
                    Date = DateTime.Today - TimeSpan.FromDays(2),
                    Account = accounts.Find(a => a.Name == "Primary Savings"),
                    Amount = 100,
                    Category = categories.Find(c => c.Name == "Dining out"),
                    OtherParty = payees.Find(p => p.Name == "Magic Diner"),
                    IsTransfer = false
                },
            };

            context.Transactions.AddRange(transactions);
            context.SaveChanges();

            #endregion
        }
    }
}
