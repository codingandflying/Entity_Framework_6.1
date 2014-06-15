using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace EFDataAccessLayer.BaseTypes
{
    public abstract class EntityBase : IValidatableObject, ISetProperty
    {
        //_________________________________________________________________________________________
        #region IValidatableObject

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ICollection<ValidationResult> res = new Collection<ValidationResult>();
            res.Add(ValidationResult.Success);
            return res;
        }
        
        #endregion

        //_________________________________________________________________________________________
        #region INotifyPropertyChanged

        /// <summary>
        /// Event subscribed by the customers to get notification when a property changes.
        /// </summary>        
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method called by the derived classes when a property changes and clients needs to be notified.
        /// </summary>
        /// <param name="propertyName">Name of the property that has been changed.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        //_________________________________________________________________________________________
        #region INotifyDataErrorInfo
        
        /// <summary>
        /// Dictionary that holds data errors for properties.
        /// </summary>
        private Dictionary<string, List<string>> _Errors = new Dictionary<string, List<string>>();

        /// <summary>
        /// Event raised when a change in error dictionary occurs.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Called by the derived classes to notify a change in the errors dictionary.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));

            RaisePropertyChanged("HasErrors");
            RaisePropertyChanged("NoErrors");
            RaisePropertyChanged("ErrorCount");
        }

        /// <summary>
        /// Used to get errors by supplying property name.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (_Errors.ContainsKey(propertyName))
                return _Errors[propertyName];
            return null;
        }

        /// <summary>
        /// Is true if at least one error is in the error dictionary.
        /// </summary>
        public bool HasErrors
        {
            get { return (_Errors.Count > 0); }
        }

        /// <summary>
        /// Returns the total number of errors in the dictionary.
        /// </summary>
        public int ErrorCount
        {
            get { return _Errors.Count; }
        }

        /// <summary>
        /// Is true if there are no errors in the dictionary.
        /// </summary>
        public bool NoErrors
        {
            get { return (_Errors.Count == 0); }
        }

        /// <summary>
        /// Sets the errors for a property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">An IEnumerable containing the errors. If this parameter is null,
        /// all errors are cleared.</param>
        protected void SetErrors(string propertyName, IEnumerable<string> errors)
        {
            if (errors == null)
            {
                //Clean up all errors for this property if the enumeration is empty
                if (_Errors.ContainsKey(propertyName))
                {
                    _Errors.Remove(propertyName);
                    RaiseErrorsChanged(propertyName);
                }
            }
            else
            {
                //Create a new entry for the property and add the error list
                if (!_Errors.ContainsKey(propertyName))
                    _Errors.Add(propertyName, new List<string>(errors));
                else
                {
                    //Replace the whole error list with the new one
                    _Errors[propertyName] = new List<string>(errors);
                }

                RaiseErrorsChanged(propertyName);
            }
        }

        #endregion

        //_________________________________________________________________________________________
        #region ISetProperty

        /// <summary>
        /// Holds the property names and corresponding validate methods for properties.
        /// </summary>
        private Dictionary<string, Func<object, IEnumerable<string>>> _ValidateMethods = new Dictionary<string, Func<object, IEnumerable<string>>>();

        /// <summary>
        /// Adds a validation method to the dictionary.
        /// </summary>
        /// <param name="propertyName">Property that will use the validation method.</param>
        /// <param name="method">Delegate that validates the property and returns an ienumerable containing errors.</param>
        public void AddValidationMethod(string propertyName, Func<object, IEnumerable<string>> method)
        {
            _ValidateMethods.Add(propertyName, method);
        }

        /// <summary>
        /// Validates a property using the validation method in the dictionary. Called privately.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="newValue">New value that will be assigned to the property.</param>
        /// <returns> true if no errors, false otherwise.</returns>
        private bool ValidateProperty<T>(string propertyName, T newValue)
        {
            Func<object, IEnumerable<string>> validator = null;

            if (this._ValidateMethods.TryGetValue(propertyName, out validator))
            {
                IEnumerable<string> results = validator(newValue);
                SetErrors(propertyName, validator(newValue));

                if (results == null)
                    return true;
                else
                    return false;
            }
            else
                throw new MissingMethodException("No validation method is added to the validation dictionary for " + propertyName + " property.");
        }


        public void SetProperty<T>(string propertyName, ref T backingField, T newValue)
        {
            if (!object.Equals(backingField, newValue))
            {
                if (ValidateProperty<T>(propertyName, newValue))
                {
                    backingField = newValue;
                    RaisePropertyChanged(propertyName);
                }
            }
        }

        #endregion

        //_________________________________________________________________________________________
        #region Common Methods

        /// <summary>
        /// Registers a validation method for each property.
        /// </summary>
        protected abstract void RegisterValidationMethods();

        /// <summary>
        /// Resets all properties to default values.
        /// </summary>
        protected abstract void ResetProperties();

        #endregion
    }
}
