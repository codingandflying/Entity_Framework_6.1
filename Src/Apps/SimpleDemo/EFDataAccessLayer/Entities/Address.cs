using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;

namespace EFDataAccessLayer.Entities
{
    /// <summary>
    /// Holds an address for a payee. Kept as a complex type within a payee.
    /// <para>Inherits from <see cref="EntityBase"/></para>
    /// </summary>
    public class Address : EntityBase
    {
        //_________________________________________________________________________________________
        #region Stores

        private string _Street;
        private string _City;
        private string _State;
        private string _ZipCode;
        private string _Country;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Holds a street address.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Street { get { return _Street; } set { SetProperty<string>("Street", ref _Street, value); } }

        /// <summary>
        /// Holds a city name.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string City { get { return _City; } set { SetProperty<string>("City", ref _City, value); } }

        /// <summary>
        /// Holds a state name.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string State { get { return _State; } set { SetProperty<string>("State", ref _State, value); } }

        /// <summary>
        /// Holds a zip code.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string ZipCode { get { return _ZipCode; } set { SetProperty<string>("ZipCode", ref _ZipCode, value); } }

        /// <summary>
        /// Holds the country name.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Country { get { return _Country; } set { SetProperty<string>("Country", ref _Country, value); } }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public Address()
        {
            RegisterValidationMethods();
            ResetProperties();
        }

        #endregion

        //_________________________________________________________________________________________
        #region EntityBase Overrides

        protected override void RegisterValidationMethods()
        {
            AddValidationMethod("Street", this.ValidateStreet);
            AddValidationMethod("City", this.ValidateCity);
            AddValidationMethod("State", this.ValidateState);
            AddValidationMethod("ZipCode", this.ValidateZipCode);
            AddValidationMethod("Country", this.ValidateCountry);
        }

        protected override void ResetProperties()
        {
            Street = null;
            City = null;
            State = null;
            ZipCode = null;
            Country = null;
        }

        #endregion        
    }
}
