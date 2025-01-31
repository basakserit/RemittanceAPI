﻿using System;
using RemittanceAPI.Entity;

namespace RemittanceAPI.V1.Models.Response
{
    public class StatusResponse
    {
        public Guid TransactionId { get; set; } 
        public TransactionStatus TransactionStatus { get; set; }
    }
}