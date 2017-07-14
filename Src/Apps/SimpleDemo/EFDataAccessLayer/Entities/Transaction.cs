using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;
using System;

namespace EFDataAccessLayer.Entities
{
    /// <summary>
    /// Implements the transaction class which is central to the application.
    /// </summary>
    public class Transaction : EntityBase
    {
        //_________________________________________________________________________________________
        #region Stores

        private Nullable<DateTime> _Date;
        private Account _Account;
        private Payee _OtherParty;
        private Nullable<decimal> _Amount;
        private bool _IsTransfer;
        private Category _Category;
        private string _Notes;
        private Account _ReceivingAccount;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Date of the transaction.
        /// <para>Required.</para>
        /// </summary>
        public DateTime? Date { get { return _Date; } set { SetProperty<DateTime?>("Date", ref _Date, value); } }

        /// <summary>
        /// Account id that the transaction belongs.
        /// <para>Required.</para>
        /// </summary>
        public Account Account { get { return _Account; } set { SetProperty<Account>("Account", ref _Account, value); } }

        /// <summary>
        /// The other end of the transaction.
        /// <para>Required.</para>
        /// </summary>
        public Payee OtherParty { get { return _OtherParty; } set { SetProperty<Payee>("OtherParty", ref _OtherParty, value); } }

        /// <summary>
        /// Amount of the transction.
        /// <para>Required.</para>
        /// </summary>
        public decimal? Amount { get { return _Amount; } set { SetProperty<decimal?>("Amount", ref _Amount, value); } }

        /// <summary>
        /// Indicates if the transaction is a tranfer of funds to another account.
        /// <para>Required.</para>
        /// </summary>
        public bool IsTransfer { get { return _IsTransfer; } set { SetProperty<bool>("IsTransfer", ref _IsTransfer, value); } }

        /// <summary>
        /// Category of the transaction.
        /// <para>Required.</para>
        /// </summary>
        public Category Category { get { return _Category; } set { SetProperty<Category>("Category", ref _Category, value); } }

        /// <summary>
        /// Comments about the transaction.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Notes { get { return _Notes; } set { SetProperty<string>("Notes", ref _Notes, value); } }

        /// <summary>
        /// ID of the receviving account if the transaction is a transfer.
        /// <para>Not Required.</para>
        /// </summary>
        public Account ReceivingAccount
        {
            get { return _ReceivingAccount; }
            set { SetProperty<Account>("ReceivingAccount", ref _ReceivingAccount, value); }
        }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public Transaction()
        {
            RegisterValidationMethods();
            ResetProperties();
        }

        #endregion

        //_________________________________________________________________________________________
        #region EntityBase Overrides

        protected override void RegisterValidationMethods()
        {
            AddValidationMethod("Date", this.ValidateDate);
            AddValidationMethod("Account", this.ValidateNotNull);
            AddValidationMethod("OtherParty", this.ValidateNotNull);
            AddValidationMethod("Amount", this.ValidateAmount);
            AddValidationMethod("IsTransfer", this.ValidateIsTransfer);
            AddValidationMethod("Category", this.ValidateNotNull);
            AddValidationMethod("Notes", this.ValidateNotes);
            AddValidationMethod("ReceivingAccount", this.ValidateNotNull);

        }

        protected override void ResetProperties()
        {
            Date = null;
            Account = null;
            OtherParty = null;
            Amount = null;
            IsTransfer = false;
            Category = null;
            Notes = null;
            ReceivingAccount = null;
        }

        #endregion

    }
}
