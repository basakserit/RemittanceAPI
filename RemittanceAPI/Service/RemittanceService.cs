using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public class RemittanceService : IRemittanceService
    {
        //Task<ExchangeRateResponse>
        public ExchangeRateResponse FindExchangeRate(ExchangeRateRequest request)
        {
            string from = request.From;
            string to = request.To;

            // DB works...
            //ExchangeRateResponse response = dao.findExchangeRatesByFromAndTo(from,to)

            return new ExchangeRateResponse
            {
                DestinationCountry = to,
                ExchangeRate = "1.2", //use decimal here & Math.Round(per, 3)
                ExchangeRateToken = "123Ef5",
                SourceCountry = from
            };
        }

        public async Task<IEnumerable<Country>> GetCountries() //TODO: parameter = access key ?
        {
            var countries = new Country[3];;
            var c1 = new Country { Code = "US", Name = "America" };
            var c2 = new Country { Code = "SE",  Name = "Sweden"};
            var c3 = new Country { Code = "TR", Name = "Turkey" };
            countries[0] = c1;
            countries[1] = c2;
            countries[2] = c3;

            return countries;
        }

        public async Task<IEnumerable<FeeResponse>> GetFees(FeeRequest request) //TODO: parameter = access key ?
        {

            //TODO: get fee & amount values from the DB according to the request model

            var fees = new FeeResponse[3]; ;
            var f1 = new FeeResponse { Amount = 100, Fee = 0 };
            var f2 = new FeeResponse { Amount = 200, Fee = 2 };
            var f3 = new FeeResponse { Amount = 500, Fee = 6 };
            fees[0] = f1;
            fees[1] = f2;
            fees[2] = f3;

            return fees;
        }

        public async Task<string> SubmitTransaction(TransactionRequest request) //TODO: parameter = access key ?
        {

            // submit the transaction and return the transaction id as a response

            return Guid.NewGuid().ToString();
        }

        public async Task<IEnumerable<State>> GetStateList()
        {
            var states = new State[3]; ;
            var s1 = new State { Code = "TX", Name = "Texas" };
            var s2 = new State { Code = "NY", Name = "New York" };
            var s3 = new State { Code = "AK", Name = "Alaska" };
            states[0] = s1;
            states[1] = s2;
            states[2] = s3;

            return states;
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest request)
        {
            StatusResponse response = new StatusResponse();
            response.Status = "Completed";
            response.TransactionId = request.TransactionId;

            return response;
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest request)
        {
            BeneficiaryResponse response = new BeneficiaryResponse();
            response.AccountName = "My account";

            return response;
        }

        public async Task<IEnumerable<BankResponse>> GetBankList(BankRequest request)
        {
            var banks = new BankResponse[3]; ;
            var b1 = new BankResponse { Code = "TX", Name = "Texas Bank" };
            var b2 = new BankResponse { Code = "NY", Name = "NY Bank" };
            var b3 = new BankResponse { Code = "AK", Name = "Alsk Bank" };
            banks[0] = b1;
            banks[1] = b2;
            banks[2] = b3;

            return banks;
        }
    }
}
