using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RemittanceAPI.V1.Models.Request
{
    public class ExchangeRateRequest
    {
        public string From { get; set; }
        [Required]
        public string To { get; set; }
    }
}
