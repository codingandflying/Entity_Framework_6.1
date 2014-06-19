using EFDataAccessLayer.Entities;
using EFDataAccessLayer.Entities.Configuration;
using System.Data.Common;
using System.Data.Entity;

namespace EFDataAccessLayer.Model
{
    /// <summary>
    /// Central class that handles database transactions.
    /// <para>Derived from <see cref="DbContext"/></para>
    /// </summary>
    class EFDbContext : DbContext
    {
        //_________________________________________________________________________________________
        #region Properties

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Payee> Payees { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public EFDbContext()
        {
        }

        public EFDbContext(string databaseName)
            : base(databaseName)
        {
        }

        public EFDbContext(DbConnection connection, bool ownsConnection) :
            base(connection, contextOwnsConnection: ownsConnection)
        {
        }

        #endregion

        //_________________________________________________________________________________________
        #region DbContext Overrides

        /// <summary>
        /// Method override to configure model before it is created.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<AccountType>(new AccountTypeConfiguration());
            modelBuilder.Configurations.Add<Account>(new AccountConfiguration());
            modelBuilder.Configurations.Add<Category>(new CategoryConfiguration());
            modelBuilder.Configurations.Add<Payee>(new PayeeConfiguration());
            modelBuilder.Configurations.Add<PhoneNumber>(new PhoneNumberConfiguration());
            modelBuilder.Configurations.Add<Transaction>(new TransactionConfiguration());
        }

        #endregion
    }
}
