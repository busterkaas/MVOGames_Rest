﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Orderline
    {
        public int Id { get; set; }
        private int amount { get; set; }
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public int PlatformGameId { get; set; }
        public PlatformGame PlatformGame { get; set; }
        public int OrderId { get; set; }

    }
}
