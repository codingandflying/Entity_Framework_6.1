using EFDataAccessLayer;
using EFDataAccessLayer.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a facade object that is used to get a uow
            IDALFacade facade = new EFDALFacade();
            //Get a uow
            IUnitOfWork unitOfWork = facade.GetUnitOfWork();
            //Call the methods in the repositories
            var singleaccount = unitOfWork.AccountRepo.GetById(1);
            if (singleaccount != null)
            {
                Console.WriteLine("Single Account Info:");
                Console.WriteLine("Name: {0}, Number: {1} Type: {2} Bank: {3}",
                                  singleaccount.Name, singleaccount.AccountNo, 
                                  singleaccount.AccountType.TypeName, singleaccount.Bank);
            }
            //Get all accounts sorted by name
            var allaccounts = unitOfWork.AccountRepo.GetByQuery(null, q => q.OrderBy( a => a.Name));
            if (allaccounts != null)
            {
                Console.WriteLine("Account Info Sorted by name:");
                foreach (var account in allaccounts)
                {
                    Console.WriteLine("Name: {0}, Number: {1} Type: {2} Bank: {3}",
                    account.Name, account.AccountNo, account.AccountType.TypeName, account.Bank);

                }
                Console.ReadKey();
            }

            var accountsCount = unitOfWork.AccountRepo.Count();
            
            
            Console.WriteLine("Account's Count is [{0}].",accountsCount);
            Console.ReadKey();

            //Save the changes
            unitOfWork.Commit();
            //Return the uow to be disposed
            facade.ReturnUnitOfWork();

            //Get another uow
            unitOfWork = facade.GetUnitOfWork();

            Console.WriteLine("Delete Account Type whose id is 3.");
            unitOfWork.AccountTypeRepo.DeleteByID(3);
            unitOfWork.Commit();

            accountsCount = unitOfWork.AccountRepo.Count();
            
            Console.WriteLine("Account's Count is [{0}].", accountsCount);
            Console.ReadKey();
           
            facade.ReturnUnitOfWork();

            //Get another uow
            unitOfWork = facade.GetUnitOfWork();

            //Get all transactions with amounts greater than 100
            var transactions = unitOfWork.TransactionRepo.GetByQuery(t => t.Amount > 100);
            if (transactions != null)
            {
                foreach (var item in transactions)
                {
                    Console.WriteLine("Transaction amount is changed from {0} to 200.", item.Amount);
                    item.Amount = 200;
                }
                Console.ReadKey();
                //Commit the changes
                unitOfWork.Commit();
            }
            //Return the uow
            facade.ReturnUnitOfWork();

        }
    }
}
