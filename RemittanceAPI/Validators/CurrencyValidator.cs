using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RemittanceAPI.Validators
{
    public class CurrencyValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var regex = new Regex(@"^[A-Z]{3}$");
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