﻿using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable <Car>  AllCars { get; set; }

        public string CarrCategory { get; set; }


    }
}
