using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using RemittanceAPI.Exceptions;
using RemittanceAPI.Service;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;
using TransactionStatus = RemittanceAPI.Entity.TransactionStatus;

namespace RemittanceAPI.Provider
{
    public class ThirdPartyProvider : IThirdPartyProvider
    {
        private readonly IConfigurationService _configurationService;

        public ThirdPartyProvider(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<CountryResponse[]> GetCountries(string accessKey)
        {
            using var client = new HttpClient();
            var request = $"{{accessKey: {accessKey}}}";
            var result = await client.PostAsync($"{_configurationService.ThirdPartyRemittanceServiceUrl}/get-countries",
                new StringContent(request, Encoding.UTF8, MediaTypeNames.Application.Json));

            return EvaluateCall<CountryResponse[]>(result);
        }
        public async Task<BankResponse[]> GetBanks(BankRequest bankRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(bankRequest);
            var result = await client.PostAsync($"{_configurationService.ThirdPartyRemittanceServiceUrl}/get-bank-list",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));

            return EvaluateCall<BankResponse[]>(result);
        }

        public async Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(exchangeRateRequest);
            var result = await client.PostAsync($"{ _configurationService.ThirdPartyRemittanceServiceUrl}/get-exchange-rate",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<ExchangeRateResponse>(result);
        }

        public async Task<FeeResponse[]> GetFees(FeeRequest feeRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(feeRequest);
            var result = await client.PostAsync($"{ _configurationService.ThirdPartyRemittanceServiceUrl}/get-fees-list",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<FeeResponse[]>(result);
        }

        public async Task<StateResponse[]> GetStates(string accessKey)
        {
            using var client = new HttpClient();
            var request = $"{{accessKey: {accessKey}}}";
            var result = await client.PostAsync($"{_configurationService.ThirdPartyRemittanceServiceUrl}/get-state-list",
                new StringContent(request, Encoding.UTF8, MediaTypeNames.Application.Json));
            return EvaluateCall<StateResponse[]>(result);
        }

        public async Task<SubmitTransactionResponse> SubmitTransaction(TransactionRequest transactionRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(transactionRequest);
            var response = await client.PostAsync($"{_configurationService.ThirdPartyRemittanceServiceUrl}/get-fees-list",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));

            var transactionId = EvaluateCall<Guid>(response);

            return new SubmitTransactionResponse()
            {
                TransactionId = transactionId, 
                TransactionStatus = response.StatusCode == HttpStatusCode.Created ? TransactionStatus.Pending : TransactionStatus.Successful
            };
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(statusRequest);
            var result = await client.PostAsync($"{ _configurationService.ThirdPartyRemittanceServiceUrl}/get-transaction-status",
                new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json));
            
            var statusResponse = EvaluateCall<StatusResponse>(result);
            statusResponse.TransactionStatus = result.StatusCode == HttpStatusCode.Created
                ? TransactionStatus.Pending
                : TransactionStatus.Successful;

            return statusResponse;
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            using var client = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(beneficiaryRequest);
            var result = await client.PostAsync($"{_configurationService.ThirdPartyRemittanceServiceUrl}/get-beneficiary-name",
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
            }
        }
    }
}