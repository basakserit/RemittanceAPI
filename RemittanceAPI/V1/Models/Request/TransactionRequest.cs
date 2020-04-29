using System.ComponentModel.DataAnnotations;
using RemittanceAPI.Validators;

namespace RemittanceAPI.V1.Models.Request
{
    public class TransactionRequest 
    {
        [Required] 
        public string AccessKey { get; set; }
        [Required] 
        public string SenderFirstName { get; set; }
        [Required] 
        public string SenderLastName { get; set; }
        [Required] 
        public string SenderEmail { get; set; }
        [Required] 
        public string SenderPhone { get; set; }
        [Required] 
        public string SenderAddress { get; set; }
        [Required, CountryValidator(ErrorMessage = "Country code should be valid.")] 
        public string SenderCountry { get; set; }
        [Required] 
        public string SenderCity { get; set; }
        [Required] 
        public string SendFromState { get; set; }
        [Required] 
        public string SenderPostalCode { get; set; }
        [Required, DateOfBirthValidator(ErrorMessage = "Birthdate should be YYY-MM-DD format.")]
        public string DateOfBirth { get; set; }
        [Required] 
        public string ToFirstName { get; set; }
        [Required] 
        public string ToLastName { get; set; }
        [Required, CountryValidator(ErrorMessage = "Country code should be valid.")] 
        public string ToCountry { get; set; }
        [Required] 
        public string ToBankAccountName { get; set; }
        [Required] 
        public string ToBankAccountNumber { get; set; }
        [Required] 
        public string ToBankName { get; set; }
        [Required] 
        public string ToBankCode { get; set; }
        [Required] 
        public string FromAmount { get; set; }
        [Required]
        public string ExchangeRate { get; set; }
        [Required] 
        public decimal Fees { get; set; } = 0;
        [Required, MinLength(10), MaxLength(25)]
        public string TransactionNumber { get; set; }
        [Required, CurrencyValidator(ErrorMessage = "Currency code should be valid.")]
        public string FromCurrency { get; set; }
    }
}
