using System.Threading.Tasks;
using RemittanceAPI.Provider;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IThirdPartyProvider _thirdPartyProvider;

        public TransactionService(IThirdPartyProvider thirdPartyProvider)
        {
            _thirdPartyProvider = thirdPartyProvider;
        }
        public async Task<string> SubmitTransaction(TransactionRequest transactionRequest)
        {
            return await _thirdPartyProvider.SubmitTransaction(transactionRequest);
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            return await _thirdPartyProvider.GetTransactionStatus(statusRequest);
        }
    }
}