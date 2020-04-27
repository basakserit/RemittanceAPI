using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RemittanceAPI.Exceptions;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Provider
{
    public class ThirdPartyProvider : IThirdPartyProvider
    {
        public async Task<Country[]> GetCountries(string accessKey)
        {
            using var client = new HttpClient();
            var request = $"{{accessKey: {accessKey}}}";
            var result = await client.PostAsync($"{ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-countries",
                new StringContent(request, Encoding.UTF8, MediaTypeNames.Application.Json));

            return EvaluateCall<Country[]>(result);
        }
        public async Task<BankResponse[]> GetBanks(BankRequest bankRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(bankRequest);
            // var request = $"{{accessKey: {accessKey}, country: {country}}}";
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-bank-list",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));

            return EvaluateCall<BankResponse[]>(result);
        }

        public async Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(exchangeRateRequest);
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-exchange-rate",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<ExchangeRateResponse>(result);
        }

        public async Task<FeeResponse[]> GetFees(FeeRequest feeRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(feeRequest);
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-fees-list",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<FeeResponse[]>(result);
        }

        public async Task<StateResponse[]> GetStates(string accessKey)
        {
            using var client = new HttpClient();
            var request = $"{{accessKey: {accessKey}}}";
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-state-list",
                new StringContent(request, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<StateResponse[]>(result);
        }

        public async Task<string> SubmitTransaction(TransactionRequest transactionRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(transactionRequest);
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-fees-list",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<string>(result);
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(statusRequest);
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-transaction-status",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<StatusResponse>(result);
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(beneficiaryRequest);
            var result = await client.PostAsync($"{ ConfigurationManager.AppSettings["ProviderBaseUrl"]}/get-beneficiary-name",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<BeneficiaryResponse>(result);
        }

        public T EvaluateCall<T>(HttpResponseMessage result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    return JsonConvert.DeserializeObject<T>(result.Content.ToString());
                default:
                    var errorMessage = JsonConvert
                        .DeserializeObject<ThirdPartyProviderErrorMessage>(result.Content.ToString()).Error;
                    throw new ThirdPartyException(errorMessage);

                    //TODO: format error message with the code
                    /*
                     *     440 Failed
                           {
                           “error”: “Failed to get transaction status”
                           }
                     */
            }
        }
    }
}