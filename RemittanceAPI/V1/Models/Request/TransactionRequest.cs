using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RemittanceAPI.V1.Models.Request
{
    public class TransactionRequest
    {
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
        [Required]
        [StringLength(2)]
        public string SenderCountry { get; set; }
        [Required]
        public string SenderCity { get; set; }
        [Required]
        public string SendFromState { get; set; }
        [Required]
        public string SenderPostalCode { get; set; }
        [Required]
        public string DateOfBirth { get; set; } //TODO format: YYYY-MM-DD
        [Required]
        public string ToFirstName { get; set; }
        [Required]
        public string ToLastName { get; set; }
        [Required, StringLength(2)]
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
        [Required, DefaultValue(0)]
        public int Fees { get; set; }
        [Required, MinLength(10), MaxLength(25)]
        public string TransactionNumber { get; set; }
        [Required, StringLength(3)]
        public string FromCurrency { get; set; }
    }
}
