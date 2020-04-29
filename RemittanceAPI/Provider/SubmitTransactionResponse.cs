using System;
using RemittanceAPI.Entity;

namespace RemittanceAPI.Provider
{
    public class SubmitTransactionResponse
    {
        public Guid TransactionId { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}