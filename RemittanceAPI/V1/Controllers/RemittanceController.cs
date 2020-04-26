using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemittanceAPI.Service;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RemittanceController : ControllerBase
    {
        private readonly IRemittanceService _remittanceService;

        public RemittanceController(IRemittanceService remittanceService)
        {
            _remittanceService = remittanceService;
        }

        /* TODO: responses
         * 200/201 Success
            400 Invalid Request
            401 Unauthorized
            403 Forbidden
            440 Failed
            503 Service Unavailable
         *
         * return type may be ActionResult<model> ??
         */

        [HttpPost("get-exchange-rate")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExchangeRateResponse), StatusCodes.Status200OK)] //200, 201 OK
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ExchangeRateResponse> GetExchangeRate([FromBody] ExchangeRateRequest request)
        {
            return await _remittanceService.FindExchangeRate(request);
        }

        [HttpPost("get-country-list")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Country>), StatusCodes.Status200OK)] //200, 201 OK
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Country>> GetCountryList()
        {
            return await _remittanceService.GetCountries();
        }

        [HttpPost("get-fees-list")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<FeeResponse>), StatusCodes.Status200OK)] //200, 201 OK
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<FeeResponse>> GetFeeList([FromBody] FeeRequest request)
        {
            //authorization check
            // if not authorized > return 401 unauthorized

            // from and to should be a valid country code, validate with the country codes in the db
            // if not valid model > return 400 invalid request

             // 403? 503? 440?

            return await _remittanceService.GetFees(request);
        }

        [HttpPost("submit-transaction")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK), //TODO: 200 Success
         ProducesResponseType(typeof(string), StatusCodes.Status201Created)]  //TODO: 201 Success. Pending payout to beneficiary
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<string> SubmitTransaction([FromBody] TransactionRequest request)
        {
            // var result = await _remittanceService.SubmitTransaction(request);
            // return Ok(result); ??

            return await _remittanceService.SubmitTransaction(request);
        }

        [HttpPost("get-state-list")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<State>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<State>> GetStateList()
        {
            return await _remittanceService.GetStateList();
        }

        [HttpPost("get-transaction-status")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]  
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<StatusResponse> GetTransactionStatus([FromBody] StatusRequest request)
        {
            request.TransactionId = Guid.NewGuid().ToString();
            return await _remittanceService.GetTransactionStatus(request);
        }

        [HttpPost("get-beneficiary-name")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BeneficiaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<BeneficiaryResponse> GetBeneficiaryName([FromBody] BeneficiaryRequest request)
        {
            return await _remittanceService.GetBeneficiaryName(request);
        }

        [HttpPost("get-bank-list")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<BankResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<BankResponse>> GetBankList([FromBody] BankRequest request)
        {
            return await _remittanceService.GetBankList(request);
        }
    }
}