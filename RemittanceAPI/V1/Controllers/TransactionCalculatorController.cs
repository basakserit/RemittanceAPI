using System.Collections.Generic;
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
    public class TransactionCalculatorController : ControllerBase
    {
        private readonly ITransactionCalculatorService _transactionCalculatorService;

        public TransactionCalculatorController(ITransactionCalculatorService transactionCalculatorService)
        {
            _transactionCalculatorService = transactionCalculatorService;
        }

        [HttpGet("GetExchangeRate")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExchangeRateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExchangeRate([FromQuery] ExchangeRateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _transactionCalculatorService.GetExchangeRate(request));
        }

        [HttpGet("GetFeeList")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<FeeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFeeList([FromQuery] FeeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _transactionCalculatorService.GetFees(request));
        }

    }
}