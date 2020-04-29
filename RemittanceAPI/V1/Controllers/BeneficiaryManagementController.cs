using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class BeneficiaryManagementController : Controller
    {
        private readonly IBeneficiaryManagementService _beneficiaryManagementService;

        public BeneficiaryManagementController(IBeneficiaryManagementService beneficiaryManagementService)
        {
            _beneficiaryManagementService = beneficiaryManagementService;
        }

        [HttpGet("GetBeneficiaryName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BeneficiaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBeneficiaryName([FromQuery] BeneficiaryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _beneficiaryManagementService.GetBeneficiaryName(request));
        }

        [HttpGet("GetCountryList")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<CountryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountryList([Required, FromQuery] string accessKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _beneficiaryManagementService.GetCountries(accessKey));
        }

        [HttpGet("GetStateList")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<StateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStateList([Required, FromQuery] string accessKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _beneficiaryManagementService.GetStateList(accessKey));
        }


        [HttpGet("GetBankList")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<BankResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBankList([FromQuery] BankRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _beneficiaryManagementService.GetBankList(request));
        }
    }
}