using EFDataAccessLayer.Entities;
using System;
using System.Data.Entity;

namespace EFDataAccessLayer.BaseTypes
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        //_________________________________________________________________________________________
        #region Stores

        private DbContext _DbContext = null;
        private bool _Disposed = false;

        private IRepository<AccountType> _AccountTypeRepo = null;
        private IRepository<Account> _AccountRepo = null;
        private IRepository<Category> _CategoryRepo = null;
        private IRepository<Payee> _PayeeRepo = null;
        private IRepository<PhoneNumber> _PhoneNumberRepo = null;
        private IRepository<Transaction> _TransactionRepo = null;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        public IRepository<AccountType> AccountTypeRepo
        {
            get
            {
                if (_AccountTypeRepo == null)
                    _AccountTypeRepo = new Repository<AccountType>(_DbContext);

                return _AccountTypeRepo;
            }
        }
        public IRepository<Account> AccountRepo
        {
            get
            {
                if (_AccountRepo == null)
                    _AccountRepo = new Repository<Account>(_DbContext);

                return _AccountRepo;
            }
        }
        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (_CategoryRepo == null)
                    _CategoryRepo = new Repository<Category>(_DbContext);

                return _CategoryRepo;
            }
        }
        public IRepository<Payee> PayeeRepo
        {
            get
            {
                if (_PayeeRepo == null)
                    _PayeeRepo = new Repository<Payee>(_DbContext);

                return _PayeeRepo;
            }
        }
        public IRepository<PhoneNumber> PhoneNumberRepo
        {
            get
            {
                if (_PhoneNumberRepo == null)
                    _PhoneNumberRepo = new Repository<PhoneNumber>(_DbContext);

                return _PhoneNumberRepo;
            }
        }
        public IRepository<Transaction> TransactionRepo
        {
            get
            {
                if (_TransactionRepo == null)
                    _TransactionRepo = new Repository<Transaction>(_DbContext);

                return _TransactionRepo;
            }
        }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        /// <summary>
        /// Injects the DbContext
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DbContext context)
        {
            _DbContext = context;
        }

        #endregion

        //_________________________________________________________________________________________
        #region Public Methods

        /// <summary>
        /// Used to save the changes to the underlying data store.
        /// </summary>
        public virtual void Commit()
        {
            _DbContext.SaveChanges();
        }

        #endregion

        //_________________________________________________________________________________________
        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this._Disposed)
            {
                if (disposing)
                    _DbContext.Dispose();
            }
            this._Disposed = true;
        }

        #endregion

        //_________________________________________________________________________________________
        #region IDisposable Overrides

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
