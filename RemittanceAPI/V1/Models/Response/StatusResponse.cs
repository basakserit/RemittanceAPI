namespace RemittanceAPI.V1.Models.Response
{
    public class StatusResponse
    {
        public string TransactionId { get; set; } //Guid?
        public string Status { get; set; }
    }
}