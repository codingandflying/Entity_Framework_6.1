using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;
using System;

namespace EFDataAccessLayer.Entities
{
    /// <summary>
    /// Class to represent an account in the application. Inherits from <see cref="EntityBase"/>.
    /// </summary>
    public class Account : EntityBase
    {
        //_________________________________________________________________________________________
        #region Stores

        private string _Name;
        private string _Bank;
        private string _AccountNo;
        private AccountType _AccountType;
        private bool _IsActive;
        private string _Currency;
        private string _CurrencySymbol;
        private Nullable<DateTime> _OpeningDate;
        private Nullable<DateTime> _ClosingDate;
        private Nullable<decimal> _OpeningBalance;
        private Nullable<decimal> _CurrentBalance;
        private Nullable<decimal> _LimitBalance;
        private string _Comment;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Account Name.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty<string>("Name", ref _Name, value); }
        }

        /// <summary>
        /// Financial Institution Name.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Bank
        {
            get { return _Bank; }
            set { SetProperty<string>("Bank", ref _Bank, value); }
        }

        /// <summary>
        /// Account No.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string AccountNo
        {
            get { return _AccountNo; }
            set { SetProperty<string>("AccountNo", ref _AccountNo, value); }
        }

        /// <summary>
        /// Account Type.
        /// <para>Required.</para>
        /// </summary>
        public virtual AccountType AccountType
        {
            get { return _AccountType; }
            set { SetProperty<AccountType>("AccountType", ref _AccountType, value); }
        }

        /// <summary>
        /// Account Activity Status.
        /// <para>Required.</para>
        /// </summary>
        public bool IsActive
        {
            get { return _IsActive; }
            set { SetProperty<bool>("IsActive", ref _IsActive, value); }
        }

        /// <summary>
        /// Currency Name. Used for display only.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string Currency
        {
            get { return _Currency; }
            set { SetProperty<string>("Currency", ref _Currency, value); }
        }

        /// <summary>
        /// Currency Symbol.
        /// <para>Required.</para>
        /// <para>Length: 3</para>
        /// </summary>
        public string CurrencySymbol
        {
            get { return _CurrencySymbol; }
            set { SetProperty<string>("CurrencySymbol", ref _CurrencySymbol, value); }
        }

        /// <summary>
        /// Account Opening Date.
        /// <para>Not Required.</para>
        /// <para>Nullable.</para>
        /// </summary>
        public DateTime? OpeningDate
        {
            get { return _OpeningDate; }
            set { SetProperty<DateTime?>("OpeningDate", ref _OpeningDate, value); }
        }

        /// <summary>
        /// Account Closing Date.
        /// <para>Not Required.</para>
        /// <para>Nullable.</para>
        /// </summary>
        public DateTime? ClosingDate
        {
            get { return _ClosingDate; }
            set { SetProperty<DateTime?>("ClosingDate", ref _ClosingDate, value); }
        }

        /// <summary>
        /// Initial Account Balance.
        /// <para>Required.</para>
        /// </summary>
        public decimal? OpeningBalance
        {
            get { return _OpeningBalance; }
            set { SetProperty<decimal?>("OpeningBalance", ref _OpeningBalance, value); }
        }

        /// <summary>
        /// Current Account Balance. Calculated internally by the application.
        /// <para>Required.</para>
        /// </summary>
        public decimal? CurrentBalance
        {
            get { return _CurrentBalance; }
            set { SetProperty<decimal?>("CurrentBalance", ref _CurrentBalance, value); }
        }

        /// <summary>
        /// Account Balance Limit. USed for credit accounts.
        /// <para>Not Required.</para>
        /// </summary>
        public decimal? LimitBalance
        {
            get { return _LimitBalance; }
            set { SetProperty<decimal?>("LimitBalance", ref _LimitBalance, value); }
        }

        /// <summary>
        /// Notes about the account.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.LongStringLength</para>
        /// </summary>
        public string Comment
        {
            get { return _Comment; }
            set { SetProperty<string>("Comment", ref _Comment, value); }
        }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public Account()
        {
            RegisterValidationMethods();

            ResetProperties();

        }

        #endregion

        //_________________________________________________________________________________________
        #region EntityBase Overrides

        protected override void RegisterValidationMethods()
        {
            AddValidationMethod("Name", this.ValidateName);
            AddValidationMethod("Bank", this.ValidateBank);
            AddValidationMethod("AccountNo", this.ValidateAccountNo);
            AddValidationMethod("AccountType", this.ValidateAccountTypeNotNull);
            AddValidationMethod("IsActive", this.ValidateIsActive);
            AddValidationMethod("Currency", this.ValidateCurrencyName);
            AddValidationMethod("CurrencySymbol", this.ValidateCurrencySymbol);
            AddValidationMethod("OpeningDate", this.ValidateDate);
            AddValidationMethod("ClosingDate", this.ValidateDate);
            AddValidationMethod("OpeningBalance", this.ValidateBalanceNotNull);
            AddValidationMethod("CurrentBalance", this.ValidateBalanceNotNull);
            AddValidationMethod("LimitBalance", this.ValidateBalanceNotNull);
            AddValidationMethod("Comment", this.ValidateComment);
        }

        protected override void ResetProperties()
        {
            Name = null;
            Bank = null;
            AccountNo = null;
            AccountType = null;
            IsActive = true;
            Currency = null;
            CurrencySymbol = null;
            OpeningDate = null;
            ClosingDate = null;
            OpeningBalance = null;
            CurrentBalance = null;
            LimitBalance = null;
            Comment = null;
        }

        #endregion

    }
}
