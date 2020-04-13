using System;
using System.ComponentModel.DataAnnotations;

namespace Time_Display.Models
{
    public class FutureDataAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime now = DateTime.Now;
            if (((DateTime)value) > now)
                return new ValidationResult("Date cannot be in the future");
            return ValidationResult.Success;
        }

    }
}