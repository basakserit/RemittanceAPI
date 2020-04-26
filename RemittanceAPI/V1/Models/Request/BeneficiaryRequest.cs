using System.ComponentModel.DataAnnotations;

namespace RemittanceAPI.V1.Models.Request
{
    public class BeneficiaryRequest 
    {
        [Required]
        public string AccessKey { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string BankCode { get; set; }
    }
}