﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyService.Models
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Zipcode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public VendorDto VendorObj { get; set; }
    }
}
