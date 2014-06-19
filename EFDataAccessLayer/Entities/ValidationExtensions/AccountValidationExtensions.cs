using EFDataAccessLayer.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    /// <summary>
    /// Implements extension methods of <see cref="Account"/> class, which are used for property level
    /// <para>data validation.</para>
    /// </summary>
    internal static class AccountValidationExtensions
    {
        //_________________________________________________________________________________________
        #region string Validation Methods
        /// <summary>
        /// Extension method used for account name validation. Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateName(this Account account, object value)
        {
            return (CommonValidation.ValidateString("Account Name", value, Settings.Default.LongStringLength, 1, true));
        }

        /// <summary>
        /// Extension method used for financial institute name validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateBank(this Account account, object value)
        {
            return (CommonValidation.ValidateString("Financial Institution Name", value, Settings.Default.MediumStringLength));
        }

        /// <summary>
        /// Extension method used for account number validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateAccountNo(this Account account, object value)
        {
            return (CommonValidation.ValidateString("Account Number", value, Settings.Default.ShortStringLength));
        }

        /// <summary>
        /// Extension method used for currency name validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateCurrencyName(this Account account, object value)
        {
            return (CommonValidation.ValidateString("Currency Name", value, Settings.Default.ShortStringLength, 1, true));
        }

        /// <summary>
        /// Extension method used for currency symbol validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateCurrencySymbol(this Account account, object value)
        {
            return (CommonValidation.ValidateString("Currency Symbol", value, 3, 3, true));
        }

        /// <summary>
        /// Extension method used for comment property validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateComment(this Account account, object value)
        {
            return (CommonValidation.ValidateString("Comment", value, Settings.Default.LongStringLength));
        }

        #endregion

        /// <summary>
        /// Validates that account type is not null.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns></returns>
        internal static IEnumerable<string> ValidateAccountTypeNotNull(this Account account, object value)
        {
            if (value == null)
            {
                Collection<string> errors = new Collection<string>();
                errors.Add("\"Account Type\" must be selected.");
                return errors;
            }
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>Always no errors.</returns>
        internal static IEnumerable<string> ValidateIsActive(this Account account, object value)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>Always no errors.</returns>
        internal static IEnumerable<string> ValidateDate(this Account account, object value)
        {
            return null;
        }

        internal static IEnumerable<string> ValidateBalanceNotNull(this Account account, object value)
        {
            if (value == null)
            {
                Collection<string> errors = new Collection<string>();
                errors.Add("\"Balance Field\" can not be emtpy.");
                return errors;
            }
            else
                return null;
        }
    }
}
