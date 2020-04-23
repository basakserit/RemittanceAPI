using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemittanceAPI.V1.Models.Request
{
    public class FeeRequest
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}
