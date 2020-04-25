using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public interface IRemittanceService
    {
        //TODO: access key as a parameter for all

        public Task<ExchangeRateResponse> FindExchangeRate(ExchangeRateRequest request);
        public Task<IEnumerable<Country>> GetCountries(); 
        public Task<IEnumerable<FeeResponse>> GetFees(FeeRequest request);
        public Task<string> SubmitTransaction(TransactionRequest request);
        public Task<IEnumerable<State>> GetStateList();
        public Task<StatusResponse> GetTransactionStatus(StatusRequest request);
        public Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest request);
        public Task<IEnumerable<BankResponse>> GetBankList(BankRequest request);
    }
}
