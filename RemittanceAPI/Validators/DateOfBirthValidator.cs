using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RemittanceAPI.Validators
{
    public class DateOfBirthValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var memberNames = new List<string>();
            try
            {
                var regex = new Regex(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))");
                var dateOfBirthValue = value as string;
                if (string.IsNullOrEmpty(dateOfBirthValue) || !regex.IsMatch(dateOfBirthValue))
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