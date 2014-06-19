using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    internal static class CategoryValidationExtensions
    {
        /// <summary>
        /// Extension method used for account name validation. Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateName(this Category category, object value)
        {
            return (CommonValidation.ValidateString("Account Name", value, Settings.Default.ShortStringLength, 1, true));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns no errors always.</returns>
        internal static IEnumerable<string> ValidateIsMainCategory(this Category category, object value)
        {
            return null;
        }

        /// <summary>
        /// Checks if a root category has a parent category.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Errors if a root has another parent.</returns>
        internal static IEnumerable<string> ValidateParentCategory(this Category category, object value)
        {
            if ((value != null) && (category.IsMainCategory == true))
            {
                Collection<string> errors = new Collection<string>();
                errors.Add("\"Main Categories\" can not have parent categories.");
                return errors;
            }
            else
                return null;
        }

        /// <summary>
        /// Extension method used for comment property validation. 
        /// Calls ValidateString method after setting parameters.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateComment(this Category category, object value)
        {
            return (CommonValidation.ValidateString("Comment", value, Settings.Default.LongStringLength));
        }
    }
}
