using System;
using System.Threading.Tasks;
using RemittanceAPI.Entity;
using RemittanceAPI.Provider;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Test.Integration
{
    public class FakeThirdPartyProvider : IThirdPartyProvider
    {
        public async Task<CountryResponse[]> GetCountries(string accessKey)
        {
            var countries = new CountryResponse[3]; ;
            var c1 = new CountryResponse { Code = "US", Name = "America" };
            var c2 = new CountryResponse { Code = "SE", Name = "Sweden" };
            var c3 = new CountryResponse { Code = "TR", Name = "Turkey" };
            countries[0] = c1;
            countries[1] = c2;
            countries[2] = c3;

            return await Task.FromResult(countries);
        }

        public async Task<BankResponse[]> GetBanks(BankRequest bankRequest)
        {
            var banks = new BankResponse[3]; ;
            var b1 = new BankResponse { Code = "TX", Name = "Texas Bank" };
            var b2 = new BankResponse { Code = "NY", Name = "NY Bank" };
            var b3 = new BankResponse { Code = "AK", Name = "Alsk Bank" };
            banks[0] = b1;
            banks[1] = b2;
            banks[2] = b3;

            return await Task.FromResult(banks);
        }

        public async Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            var response = new ExchangeRateResponse
            {
                DestinationCountry = exchangeRateRequest.To,
                ExchangeRate = new decimal(1.2),                
                ExchangeRateToken = "123Ef5",
                SourceCountry = exchangeRateRequest.From
            };

            return await Task.FromResult(response);
        }

        public async Task<FeeResponse[]> GetFees(FeeRequest feeRequest)
        {
            var fees = new FeeResponse[3]; ;
            var f1 = new FeeResponse { Amount = 100, Fee = 0 };
            var f2 = new FeeResponse { Amount = 200, Fee = 2 };
            var f3 = new FeeResponse { Amount = 500, Fee = 6 };
            fees[0] = f1;
            fees[1] = f2;
            fees[2] = f3;

            return await Task.FromResult(fees);
        }

        public async Task<StateResponse[]> GetStates(string accessKey)
        {
            var states = new StateResponse[3]; ;
            var s1 = new StateResponse { Code = "TX", Name = "Texas" };
            var s2 = new StateResponse { Code = "NY", Name = "New York" };
            var s3 = new StateResponse { Code = "AK", Name = "Alaska" };
            states[0] = s1;
            states[1] = s2;
            states[2] = s3;

            return await Task.FromResult(states);
        }

        public async Task<SubmitTransactionResponse> SubmitTransaction(TransactionRequest transactionRequest)
        {
            return await Task.FromResult(new SubmitTransactionResponse()
            {
                TransactionStatus = TransactionStatus.Pending,
                TransactionId = Guid.NewGuid()
            });
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            var response = new StatusResponse() { TransactionStatus = TransactionStatus.Completed, TransactionId = statusRequest.TransactionId };
            return await Task.FromResult(response);
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            var response = new BeneficiaryResponse() { AccountName = "My account" };
            return await Task.FromResult(response);
        }
    }
}