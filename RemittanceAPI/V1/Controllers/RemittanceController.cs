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

        /* 
         * 200/201 Success
            400 Invalid Request
            401 Unauthorized
            403 Forbidden
            440 Failed
            503 Service Unavailable
         *
         */

        [HttpPost("get-exchange-rate")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExchangeRateResponse), StatusCodes.Status200OK)] //200, 201 OK
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ExchangeRateResponse> GetExchangeRate(
            [FromQuery]
            [Optional][DefaultParameterValue("US")]string from, 
            [Required] string to)
        {
            var request = new ExchangeRateRequest {From = from, To = to};
            return _remittanceService.FindExchangeRate(request);
        }

        [HttpPost("get-country-list")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CountryResponse), StatusCodes.Status200OK)] //200, 201 OK
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Country>> GetCountryList()
        {
            return await _remittanceService.GetCountries();
        }


}
}