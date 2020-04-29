using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemittanceAPI.Entity;

namespace RemittanceAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly EFContext _efContext;

        public TransactionRepository(EFContext efContext)
        {
            this._efContext = efContext;
        }

        public Transaction Get(Guid transactionId)
        {
            return _efContext.Transactions.FirstOrDefault(x => x.TransactionId.Equals(transactionId));
        }

        public Transaction Update(Transaction transaction)
        {
            var changes = _efContext.Transactions.Update(transaction);
            _efContext.SaveChanges();
            return changes.Entity;
        }

        public Transaction Add(Transaction transaction)
        {
            var added = _efContext.Add(transaction);
            _efContext.SaveChanges();
            return added.Entity;
        }
    }
}