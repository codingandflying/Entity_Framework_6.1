using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer.Entities.ValidationExtensions
{
    internal static class CommonValidation
    {
        /// <summary>
        /// Called internally to validate string properties.
        /// </summary>
        /// <param name="friendlyName">User friendly name of the property.</param>
        /// <param name="newValue">Value to be checked against constraints.</param>
        /// <param name="maxLength">Maximum allowed length for the property.</param>
        /// <param name="minLength">Minimum allowed length for the property.</param>
        /// <param name="isRequired">Parameter to check for null values.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateString(string friendlyName, object newValue,
                                                          int maxLength, int minLength = 0, bool isRequired = false)
        {
            string value = newValue as string;
            Collection<string> errors = null;

            if (value == null && isRequired)
            {
                errors = new Collection<string>();
                errors.Add("\"" + friendlyName + "\" can not be empty.");
            }
            else if ((minLength == maxLength) &&
                     ((value.Length < minLength) || (value.Length > maxLength)))
            {
                errors = new Collection<string>();
                errors.Add("\"" + friendlyName + "\" length must be " + minLength.ToString() + " characters.");
            }
            else if (value.Length < minLength)
            {
                errors = new Collection<string>();
                errors.Add("\"" + friendlyName + "\" length can not be less than " + minLength.ToString() + " characters.");
            }
            else if (value.Length > maxLength)
            {
                errors = new Collection<string>();
                errors.Add("\"" + friendlyName + "\" length can not be greater than " + maxLength.ToString() + " characters.");
            }

            return errors;
        }

        /// <summary>
        /// Called internally to validate an email string.
        /// </summary>
        /// <param name="friendlyName">User friendly name of the property.</param>
        /// <param name="newValue"></param>
        /// <param name="maxLength">Maximum allowed length for the property.</param>
        /// <param name="isRequired">Parameter to check for null values.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateEmail(string friendlyName, object newValue, 
                                                            int maxLength, bool isRequired = false)
        {
            List<string> errors = null;
            var valueString = newValue as string;

            //Check for null value
            if (valueString == null)
            {
                if (isRequired)
                {
                    errors = new List<string>();
                    errors.Add(friendlyName + " can not be null.");
                }
            }
            else
            {
                //Check for correct format
                try
                {
                    new MailAddress(valueString);    
                }
                catch (FormatException fe)
                {
                    errors = new List<string>();
                    errors.Add(fe.Message);
                }

                //Check for maximum length
                if (valueString.Length > maxLength)
                {
                    if (errors == null)
                        errors = new List<string>();

                    errors.Add(friendlyName + " length is greater than maximum allowed length of "+ maxLength+" characters.");
                }
            }

            return errors;
        }

        /// <summary>
        /// Validates a url
        /// </summary>
        /// <param name="friendlyName">User friendly name of the property.</param>
        /// <param name="newValue"></param>
        /// <param name="maxLength">Maximum allowed length for the property.</param>
        /// <param name="isRequired">Parameter to check for null values.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidateUrl(string friendlyName, object newValue,
                                                            int maxLength, bool isRequired = false)
        {
            List<string> errors = null;
            var valueString = newValue as string;

            //Check for null value
            if (valueString == null)
            {
                if (isRequired)
                {
                    errors = new List<string>();
                    errors.Add(friendlyName + " can not be null.");
                }
            }
            else
            {
                Uri dummyUri;

                //Check for valid format
                if (!Uri.TryCreate(valueString, UriKind.RelativeOrAbsolute, out dummyUri))
                {
                    errors = new List<string>();
                    errors.Add(friendlyName + " has invalid format.");
                }

                //Check for maximum allowed length
                if (valueString.Length > maxLength)
                {
                    if (errors == null)
                        errors = new List<string>();
                    errors.Add(friendlyName + " length is greater than maximum allowed " + maxLength + " characters.");
                }
            }
            return errors;
        }

        /// <summary>
        /// Validates a phone number against a null constraint and a maximum length constraint
        /// </summary>
        /// <param name="friendlyName">User friendly name of the property.</param>
        /// <param name="newValue"></param>
        /// <param name="maxLength">Maximum allowed length for the property.</param>
        /// <param name="isRequired">Parameter to check for null values.</param>
        /// <returns>An enumerable containing errors, or null if no errors.</returns>
        internal static IEnumerable<string> ValidatePhoneNumber(string friendlyName, object newValue,
                                                            int maxLength, bool isRequired = false)
        {
            //Phone numbers can have a lot of variety, so only validate for null and maximum values.
            List<string> errors = null;
            var valueString = newValue as string;

            //Check for null value
            if (valueString == null)
            {
                if (isRequired)
                {
                    errors = new List<string>();
                    errors.Add(friendlyName + " can not be null.");
                }
            }
            else
            {
                //Check for maximum allowed length
                if (valueString.Length > maxLength)
                {
                    errors.Add(friendlyName + " length is greater than maximum allowed " + maxLength + " characters.");
                }
            }
            return errors;

        }
    }
}
