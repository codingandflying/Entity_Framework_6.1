using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    /// <summary>
    /// Implements extension methods of <see cref="AccountType"/> class, which are used for property level
    /// <para>data validation.</para>
    /// </summary>
    internal static class AccountTypeValidationExtensions
    {
        /// <summary>
        /// Extension method used for account type name validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateTypeName(this AccountType accountType, object value)
        {
            return (CommonValidation.ValidateString("Account Type", value, Settings.Default.ShortStringLength, 1, true));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>Always no errors.</returns>
        internal static IEnumerable<string> ValidateCanBeNegative(this AccountType accountType, object value)
        {
            return null;
        }


    }
}
