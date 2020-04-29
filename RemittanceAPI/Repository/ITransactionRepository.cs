using System;
using System.Threading.Tasks;
using RemittanceAPI.Entity;

namespace RemittanceAPI.Repository
{
    public interface ITransactionRepository
    {
        Transaction Get(Guid transactionId);
        Transaction Update(Transaction transaction);
        Transaction Add(Transaction transaction);
    }
}