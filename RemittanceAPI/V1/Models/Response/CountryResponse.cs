using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemittanceAPI.V1.Models.Response
{
    public class CountryResponse
    {
        public Country[] CountryList { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
