using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;

namespace EFDataAccessLayer.Entities
{
    /// <summary>
    /// Holds a phone number for a payee.
    /// </summary>
    public class PhoneNumber : EntityBase
    {
        //_________________________________________________________________________________________
        #region Stores

        private string _Description;
        private string _Number;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Phone number.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string Number { get { return _Number; } set { SetProperty<string>("Number", ref _Number, value); } }

        /// <summary>
        /// Phone number description.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string Description { get { return _Description; } set { SetProperty<string>("Description", ref _Description, value); } }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public PhoneNumber()
        {
            RegisterValidationMethods();
            ResetProperties();
        }

        #endregion

        //_________________________________________________________________________________________
        #region EntityBase Overrides

        protected override void RegisterValidationMethods()
        {
            AddValidationMethod("Description", this.ValidateDescription);
            AddValidationMethod("Number", this.ValidateNumber);
        }

        protected override void ResetProperties()
        {
            Description = null;
            Number = null;
        }

        #endregion
    }
}
