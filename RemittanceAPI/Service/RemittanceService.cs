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

        public async Task<IEnumerable<Country>> GetCountries() //parameter = access key ?
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


    }
}
