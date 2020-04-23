using System.ComponentModel.DataAnnotations;

namespace RemittanceAPI.V1.Models.Request
{
    public class StatusRequest
    {
        //TODO: Transaction ID returned from submit-transaction or transactionNumber
        [Required]
        public string TransactionId { get; set; } //Guid?
    }
    
}