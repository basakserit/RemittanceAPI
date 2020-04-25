using RemittanceAPI.V1.Models.Request;

namespace RemittanceAPI.Helper
{
    public interface IExchangeRateValidator
    {
        public void ValidateRequestModel(ExchangeRateRequest request);
    }
}