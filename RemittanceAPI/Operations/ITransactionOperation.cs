using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Operations
{
    public interface ITransactionOperation
    {
        public Task<ExchangeRateResponse> FindExchangeRate(ExchangeRateRequest exchangeRateRequest);

        public Task<string> SubmitTransaction(TransactionRequest transactionRequest);

        public Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest);

        public Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest);
    }
}