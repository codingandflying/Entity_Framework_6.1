using System.Collections.Generic;

namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    /// <summary>
    /// Implements validation extension methods for <see cref="Transaction"/> class.
    /// </summary>
    internal static class TransactionValidatonExtensions
    {
        internal static IEnumerable<string> ValidateNotNull(this Transaction transaction, object value)
        {
            if (value != null)
                return null;
            else
                return new List<string>() { "This field can not be null" };
        }

        internal static IEnumerable<string> ValidateDate(this Transaction transaction, object value)
        {
            return null;
        }

        internal static IEnumerable<string> ValidateAmount(this Transaction transaction, object value)
        {
            return null;
        }

        internal static IEnumerable<string> ValidateIsTransfer(this Transaction transaction, object value)
        {
            return null;
        }

        internal static IEnumerable<string> ValidateNotes(this Transaction transaction, object value)
        {
            return CommonValidation.ValidateString("Transaction Notes", value, Settings.Default.MediumStringLength);
        }

    }
}
