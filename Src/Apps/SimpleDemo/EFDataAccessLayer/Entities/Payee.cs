using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;
using System.Collections.Generic;
using System.Linq;

namespace EFDataAccessLayer.Entities
{
    public class Payee : EntityBase
    {
        //_________________________________________________________________________________________
        #region Stores

        private string _Name;
        private Address _Address;
        private ICollection<PhoneNumber> _PhoneNumbers;
        private string _Email;
        private string _Website;
        private string _Memo;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Address of the payee as a complex type.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Name { get { return _Name; } set { SetProperty<string>("Name", ref _Name, value); } }

        /// <summary>
        /// Address of the payee as a complex type.
        /// <para>Required.</para>
        /// </summary>
        public Address Address { get { return _Address; } set { SetProperty<Address>("Address", ref _Address, value); } }

        /// <summary>
        /// Holds a collection of phone numbers.
        /// <para>Not Required.</para>
        /// </summary>
        public ICollection<PhoneNumber> PhoneNumbers
        {
            get { return _PhoneNumbers; }
            set { SetProperty<ICollection<PhoneNumber>>("PhoneNumbers", ref _PhoneNumbers, value); }
        }

        /// <summary>
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Email { get { return _Email; } set { SetProperty<string>("Email", ref _Email, value); } }

        /// <summary>
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.MediumStringLength</para>
        /// </summary>
        public string Website { get { return _Website; } set { SetProperty<string>("Website", ref _Website, value); } }

        /// <summary>
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.LongStringLength</para>
        /// </summary>
        public string Memo { get { return _Memo; } set { SetProperty<string>("Memo", ref _Memo, value); } }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public Payee()
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
            //Add a dummy validation method which returns null all the time since it has own validation
            AddValidationMethod("Address", (o) => { return null; });
            //Same thing for Phone Numbers
            AddValidationMethod("PhoneNumbers", (o) => { return null; });
            AddValidationMethod("Email", this.ValidateEmail);
            AddValidationMethod("Website", this.ValidateWebsite);
            AddValidationMethod("Memo", this.ValidateMemo);
        }

        protected override void ResetProperties()
        {
            Name = null;
            Address = new Address();
            PhoneNumbers = new List<PhoneNumber>();
            Email = null;
            Website = null;
            Memo = null;
        }

        #endregion
    }
}
