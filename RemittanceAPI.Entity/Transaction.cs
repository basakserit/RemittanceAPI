using System;

namespace RemittanceAPI.Entity
{
    public class Transaction
    {
        public virtual TransactionStatus TransactionStatus { get; set; }
        public virtual int Id { get; set; }
        public virtual Guid TransactionId { get; set; }
    }
}