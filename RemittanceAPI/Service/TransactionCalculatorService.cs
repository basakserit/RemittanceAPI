using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.Provider;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public class TransactionCalculatorService : ITransactionCalculatorService
    {
        private readonly IThirdPartyProvider _thirdPartyProvider;

        public TransactionCalculatorService(IThirdPartyProvider thirdPartyProvider)
        {
            _thirdPartyProvider = thirdPartyProvider;
        }

        public async Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            ExchangeRateResponse response = await _thirdPartyProvider.GetExchangeRate(exchangeRateRequest);
            response.ExchangeRate = (decimal)System.Math.Round(response.ExchangeRate, 3);
            return response;
        }

        public async Task<ICollection<FeeResponse>> GetFees(FeeRequest feeRequest)
        {
            return await _thirdPartyProvider.GetFees(feeRequest);
        }

    }
}