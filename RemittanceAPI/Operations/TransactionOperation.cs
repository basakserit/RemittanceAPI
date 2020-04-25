using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RemittanceAPI.Helper;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Operations
{
    public class TransactionOperation : ITransactionOperation
    {
        private readonly IExchangeRateValidator _iExchangeRateValidator;
        //private readonly IExchangeRateDao _iExchangeRateDao;

        public TransactionOperation(IExchangeRateValidator iExchangeRateValidator)
        {
            _iExchangeRateValidator = iExchangeRateValidator;
        }
        public ExchangeRateResponse FindExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            _iExchangeRateValidator.ValidateRequestModel(exchangeRateRequest);

            string from = exchangeRateRequest.From;
            string to = exchangeRateRequest.To;

            // DB works...
            //ExchangeRateResponse response = _iExchangeRateDao.findExchangeRatesByFromAndTo(from,to)

            return new ExchangeRateResponse
            {
                DestinationCountry = to,
                ExchangeRate = "1.2", //should be decimal & Math.Round(per, 3)
                ExchangeRateToken = "123Ef5",
                SourceCountry = from
            };
        }

        public BeneficiaryResponse GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            // DB works...   (this may be in the other operation class)
            //BeneficiaryResponse response = _iAccountDao.GetBeneficiaryName(accountNumber, bankCode)

            BeneficiaryResponse response = new BeneficiaryResponse();
            response.AccountName = "My account";

            return response;
        }

        public StatusResponse GetTransactionStatus(StatusRequest statusRequest)
        {
            // DB works...
            //StatusResponse response = _iTransactionDTO.GetTransactionStatus(transactionId)

            StatusResponse response = new StatusResponse();
            response.Status = "Completed";
            response.TransactionId = statusRequest.TransactionId;

            return response;
        }

        public string SubmitTransaction(TransactionRequest transactionRequest)
        {
            // _iTransactionValidator.ValidateTransactionModel(transactionRequest);

            // 200 success or 201 pending responses for OK
            // 400, 401, 403, 440, 503 for error responses

            // DB works...
            //var response = _iTransactionDAO.CreateTransaction(transactionModel);

            return Guid.NewGuid().ToString();
        }
    }
}