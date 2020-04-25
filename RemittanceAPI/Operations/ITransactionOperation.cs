using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Operations
{
    public interface ITransactionOperation
    {
        public ExchangeRateResponse FindExchangeRate(ExchangeRateRequest exchangeRateRequest);

        public string SubmitTransaction(TransactionRequest transactionRequest);

        public StatusResponse GetTransactionStatus(StatusRequest statusRequest);

        public BeneficiaryResponse GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest);
    }
}