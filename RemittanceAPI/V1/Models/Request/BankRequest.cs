using System.ComponentModel.DataAnnotations;

namespace RemittanceAPI.V1.Models.Request
{
    public class BankRequest
    {
        [Required]
        public string AccessKey { get; set; }
        [Required, StringLength(2)]
        public string Country { get; set; }
    }
}