using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public interface ITransactionCalculatorService
    {
        Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest exchangeRateRequest);
        Task<ICollection<FeeResponse>> GetFees(FeeRequest feeRequest);
    }
}