using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RemittanceAPI.Provider;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Operations
{
    public class TransactionOperation : ITransactionOperation
    {
        private readonly IThirdPartyProvider _thirdPartyProvider;
        //private readonly IExchangeRateDao _iExchangeRateDao;

        public TransactionOperation(IThirdPartyProvider thirdPartyProvider)
        {
            _thirdPartyProvider = thirdPartyProvider;
        }
        
        public async Task<ExchangeRateResponse> FindExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            // return new ExchangeRateResponse
            // {
            //     DestinationCountry = to,
            //     ExchangeRate = "1.2", //should be decimal & Math.Round(per, 3)
            //     ExchangeRateToken = "123Ef5",
            //     SourceCountry = from
            // };

            return await _thirdPartyProvider.GetExchangeRate(exchangeRateRequest);
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            // DB works...   (this may be in the other operation class)
            //BeneficiaryResponse response = _iAccountDao.GetBeneficiaryName(accountNumber, bankCode)


            // return new BeneficiaryResponse(){AccountName = "My account"};
            return await _thirdPartyProvider.GetBeneficiaryName(beneficiaryRequest);
        }

        public async Task<StatusResponse> GetTransactionStatus(StatusRequest statusRequest)
        {
            // DB works...
            //StatusResponse response = _iTransactionDTO.GetTransactionById(transactionId)

            // return new StatusResponse() {Status = "Completed", TransactionId = statusRequest.TransactionId};
            return await _thirdPartyProvider.GetTransactionStatus(statusRequest);
        }

        public async Task<string> SubmitTransaction(TransactionRequest transactionRequest)
        {
            // _iTransactionValidator.ValidateTransactionModel(transactionRequest);

            // 200 success or 201 pending responses for OK
            // 400, 401, 403, 440, 503 for error responses

            // DB works...
            //var response = _iTransactionDAO.CreateTransaction(transactionModel);

            // return Guid.NewGuid().ToString();
            return await _thirdPartyProvider.SubmitTransaction(transactionRequest);
        }
    }
}