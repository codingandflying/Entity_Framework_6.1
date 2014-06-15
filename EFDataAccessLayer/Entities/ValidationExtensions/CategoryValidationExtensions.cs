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
        /// Checks if subategories have other subcategories.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Errors if a subcategory has other subcategories.</returns>
        internal static IEnumerable<string> ValidateSubCategories(this Category category, object value)
        {
            if ((value != null) && (category.IsMainCategory == false))
            {
                Collection<string> errors = new Collection<string>();
                errors.Add("\"Sub Categories\" can not have other sub categories.");
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
