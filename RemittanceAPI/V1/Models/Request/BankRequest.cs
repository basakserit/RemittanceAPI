using System.ComponentModel.DataAnnotations;
using RemittanceAPI.Validators;

namespace RemittanceAPI.V1.Models.Request
{
    public class BankRequest
    {
        [Required] 
        public string AccessKey { get; set; }
        [Required, CountryValidator(ErrorMessage = "Country code should be valid.")]
        public string Country { get; set; }
    }
}