using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public interface ITransactionService
    {
        Task<string> SubmitTransaction(TransactionRequest transactionRequest);

        Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest);
    }
}