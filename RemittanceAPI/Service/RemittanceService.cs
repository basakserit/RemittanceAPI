using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.Operations;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public class RemittanceService : IRemittanceService
    {
        
        private readonly ITransactionOperation _transactionOperation;
        private readonly IInformationOperation _informationOperation;

        public RemittanceService (ITransactionOperation transactionOperation, IInformationOperation informationOperation)
        {
            _transactionOperation = transactionOperation;
            _informationOperation = informationOperation;
        }

        //TODO: parameter = access key for all ??
        // TODO: Error responses and messages for all

        public async Task<ExchangeRateResponse> FindExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            return _transactionOperation.FindExchangeRate(exchangeRateRequest);
        }

        public async Task<IEnumerable<Country>> GetCountries() 
        {
            return await _informationOperation.GetCountryList();
        }

        public async Task<IEnumerable<FeeResponse>> GetFees(FeeRequest feeRequest) 
        {
            return await _informationOperation.GetFees(feeRequest);
        }

        public async Task<string> SubmitTransaction(TransactionRequest transactionRequest) 
        {
            return _transactionOperation.SubmitTransaction(transactionRequest);
        }

        public async Task<IEnumerable<State>> GetStateList()
        {
            return await _informationOperation.GetStateList();
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            return _transactionOperation.GetTransactionStatus(statusRequest);
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            return _transactionOperation.GetBeneficiaryName(beneficiaryRequest);
        }

        public async Task<IEnumerable<BankResponse>> GetBankList(BankRequest bankRequest)
        {
            return await _informationOperation.GetBankList(bankRequest);
        }
    }
}
