﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RemittanceAPI.V1.Models.Request
{
    public class FeeRequest
    {
        public string From { get; set; } = "US";
        [Required]
        public string To { get; set; }

    }
}
