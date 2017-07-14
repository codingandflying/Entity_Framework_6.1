

using System.Collections.Generic;
namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    internal static class AddressValidationExtensions
    {
        /// <summary>
        /// Validates the street number and name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A list of errors</returns>
        internal static IEnumerable<string> ValidateStreet(this Address address, object value)
        {
            return CommonValidation.ValidateString("Street and Street Number", value, Settings.Default.MediumStringLength);
        }

        /// <summary>
        /// Validates the city name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A list of errors</returns>
        internal static IEnumerable<string> ValidateCity(this Address address, object value)
        {
            return CommonValidation.ValidateString("City Name", value, Settings.Default.ShortStringLength);
        }

        /// <summary>
        /// Validates the state name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A list of errors</returns>
        internal static IEnumerable<string> ValidateState(this Address address, object value)
        {
            return CommonValidation.ValidateString("State Name", value, Settings.Default.ShortStringLength);
        }

        /// <summary>
        /// Validates the street number and name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A list of errors</returns>
        internal static IEnumerable<string> ValidateZipCode(this Address address, object value)
        {
            return CommonValidation.ValidateString("Zip Code", value, Settings.Default.ShortStringLength);
        }

        /// <summary>
        /// Validates the country name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A list of errors</returns>
        internal static IEnumerable<string> ValidateCountry(this Address address, object value)
        {
            return CommonValidation.ValidateString("Country Name", value, Settings.Default.MediumStringLength);
        }
    }
}
