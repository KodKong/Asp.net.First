﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartitem
    {
        public int Id { get; set; }
        public Car car { get; set; }
        public int Price { get; set; }

        public string ShopCartId { get; set; }
    }
}
