using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemittanceAPI.V1.Models.Response
{
    public class ExchangeRateResponse
    {
        public string SourceCountry { get; set; }
        public string DestinationCountry { get; set; }
        public string ExchangeRate { get; set; }
        public string ExchangeRateToken { get; set; }
    }
}
