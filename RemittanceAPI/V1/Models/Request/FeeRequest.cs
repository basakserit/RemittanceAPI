using System.ComponentModel.DataAnnotations;

namespace RemittanceAPI.V1.Models.Request
{
    public class FeeRequest
    {
        [Required]
        public string AccessKey { get; set; }
        public string From { get; set; } = "US";
        [Required]
        public string To { get; set; }

    }
}
