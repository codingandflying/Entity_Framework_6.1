using System.Collections;
using System.Collections.Generic;

namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    /// <summary>
    /// Implements validation extension methods for <see cref="Payee"/> class.
    /// </summary>
    internal static class PayeeValidationExtensions
    {
        /// <summary>
        /// Validates the name property of the <see cref="Payee"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An IEnumerable for errors.</returns>
        internal static IEnumerable<string> ValidateName(this Payee payee, object value)
        {
            return CommonValidation.ValidateString("Payee Name", value, Settings.Default.MediumStringLength, 1, true);
        }
        
        /// <summary>
        /// Validates the memo property of the <see cref="Payee"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An IEnumerable for errors.</returns>
        internal static IEnumerable<string> ValidateMemo(this Payee payee, object value)
        {
            return CommonValidation.ValidateString("Memo", value, Settings.Default.LongStringLength);
        }

        /// <summary>
        /// Validates the email property of the <see cref="Payee"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An IEnumerable for errors.</returns>
        internal static IEnumerable<string> ValidateEmail(this Payee payee, object value)
        {
            return CommonValidation.ValidateEmail("Email", value, Settings.Default.MediumStringLength);
        }

        /// <summary>
        /// Validates the website property of the <see cref="Payee"/> class.
        /// </summary>
        /// <param name="payee"></param>
        /// <param name="value"></param>
        /// <returns>An IEnumerable for errors.</returns>
        internal static IEnumerable<string> ValidateWebsite(this Payee payee, object value)
        {
            return CommonValidation.ValidateUrl("Website", value, Settings.Default.MediumStringLength);
        }
    }
}
