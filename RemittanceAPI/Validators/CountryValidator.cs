using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace RemittanceAPI.Validators
{
    public class CountryValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var regex = new Regex(@"^[A-Z]{2}$");
                var countryCode = value as string;
                if (string.IsNullOrEmpty(countryCode) || !regex.IsMatch(countryCode))
                    return new ValidationResult(ErrorMessage);
            }
            catch
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}