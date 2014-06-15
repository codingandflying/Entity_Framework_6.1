using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;

namespace EFDataAccessLayer.Entities
{
    /// <summary>
    /// Represents an account type for an account such as savings, checking, credit etc.
    /// <para>Inherits from <see cref="EntityBase"/></para>
    /// </summary>
    public class AccountType : EntityBase
    {
        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// User friendly name for the account type.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Indicates if the account can have negative balance, such as credit cards.
        /// <para>Required.</para>
        /// </summary>
        public bool CanBeNegative { get; set; }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public AccountType()
        {
            RegisterValidationMethods();
            ResetProperties();
        }

        #endregion

        //_________________________________________________________________________________________
        #region EntityBase Overrides

        protected override void RegisterValidationMethods()
        {
            AddValidationMethod("TypeName", this.ValidateTypeName);
            AddValidationMethod("CanBeNegative", this.ValidateCanBeNegative);
        }

        protected override void ResetProperties()
        {
            TypeName = null;
            CanBeNegative = false;
        }

        #endregion
    }
}
