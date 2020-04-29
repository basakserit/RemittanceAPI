using System.Threading.Tasks;
using RemittanceAPI.Entity;
using RemittanceAPI.Provider;
using RemittanceAPI.Repository;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IThirdPartyProvider _thirdPartyProvider;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IThirdPartyProvider thirdPartyProvider, ITransactionRepository transactionRepository)
        {
            _thirdPartyProvider = thirdPartyProvider;
            _transactionRepository = transactionRepository;
        }
        public async Task<string> SubmitTransaction(TransactionRequest transactionRequest)
        {
            var transactionResult = await _thirdPartyProvider.SubmitTransaction(transactionRequest);
            
            var transaction = new Transaction();
            transaction.TransactionId = transactionResult.TransactionId;
            transaction.TransactionStatus = transactionResult.TransactionStatus;

            transaction = _transactionRepository.Add(transaction);
            return transaction.TransactionId.ToString();
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            var result = await _thirdPartyProvider.GetTransactionStatus(statusRequest);

            var transaction = _transactionRepository.Get(result.TransactionId);
            transaction.TransactionStatus = result.TransactionStatus;

            _transactionRepository.Update(transaction);

            return result;
        }
    }
}