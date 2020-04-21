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
        public ExchangeRateResponse FindExchangeRate(ExchangeRateRequest request);
        public Task<IEnumerable<Country>> GetCountries();
    }
}
