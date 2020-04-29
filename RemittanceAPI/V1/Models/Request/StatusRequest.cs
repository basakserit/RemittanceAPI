using System;
using System.ComponentModel.DataAnnotations;

namespace RemittanceAPI.V1.Models.Request
{
    public class StatusRequest
    {
        [Required]
        public string AccessKey { get; set; }
        [Required]
        public Guid TransactionId { get; set; }
    }
    
}