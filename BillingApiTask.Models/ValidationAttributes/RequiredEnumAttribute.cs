using System;
using System.ComponentModel.DataAnnotations;

namespace BillingApiTask.Models.ValidationAttributes
{
    /// <summary>
    /// The validation attribute for a required enum.
    /// </summary>
    public class RequiredEnumAttribute : RequiredAttribute
    {
        /// <summary>
        /// Checks if the given value is an enum and is defined in the said enum.
        /// </summary>
        /// <param name="value">The validatable value.</param>
        /// <returns>True if is an enum and is defined in the said enum, false otherwise.</returns>
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            var type = value.GetType();
            return type.IsEnum && Enum.IsDefined(type, value); ;
        }
    }
}
