using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Provider
{
    public interface IThirdPartyProvider
    {
        public Task<Country[]> GetCountries(string accessKey);

        public Task<BankResponse[]> GetBanks(BankRequest bankRequest);

        public Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest exchangeRateRequest);

        public Task<FeeResponse[]> GetFees(FeeRequest feeRequest);

        public Task<StateResponse[]> GetStates(string accessKey);

        public Task<string> SubmitTransaction(TransactionRequest transactionRequest);

        public Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest);

        public Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest);

    }
}