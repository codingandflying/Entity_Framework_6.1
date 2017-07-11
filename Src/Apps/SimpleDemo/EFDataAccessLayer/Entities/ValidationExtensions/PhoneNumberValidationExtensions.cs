
using System.Collections.Generic;
namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    internal static class PhoneNumberValidationExtensions
    {
        /// <summary>
        /// Validates a phone number from the <see cref="PhoneNumber"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An IEnumerable cotaining errors.</returns>
        internal static IEnumerable<string> ValidateNumber(this PhoneNumber phoneNumber, object value)
        {
            string mergedName = phoneNumber.Description + " phone";
            return CommonValidation.ValidatePhoneNumber(mergedName, value, Settings.Default.ShortStringLength, true);
        }

        /// <summary>
        /// Extension method used for phone description. Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateDescription(this PhoneNumber phonenumber, object value)
        {
            return (CommonValidation.ValidateString("Phone Description", value, Settings.Default.ShortStringLength, 1, true));
        }
    }
}
