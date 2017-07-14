using EFDataAccessLayer.Entities;

namespace EFDataAccessLayer.BaseTypes
{
    /// <summary>
    /// Interface to define contract for the unit of work class.
    /// </summary>
    public interface IUnitOfWork
    {
        IRepository<AccountType> AccountTypeRepo { get; }
        IRepository<Account> AccountRepo { get; }
        IRepository<Category> CategoryRepo { get; }
        IRepository<Payee> PayeeRepo { get; }
        IRepository<PhoneNumber> PhoneNumberRepo { get; }
        IRepository<Transaction> TransactionRepo { get; }

        /// <summary>
        /// Used to save the changes to the underlying data store.
        /// </summary>
        void Commit();
    }
}
