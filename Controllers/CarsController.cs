using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controles
{
    public class CarsController : Controller 
    {
        private readonly IAllCars _AllCars;
        private readonly ICarsCategory _AllCategory; 

        public CarsController (IAllCars _AllCars, ICarsCategory _AllCategory)
        {
            this._AllCars = _AllCars;
            this._AllCategory = _AllCategory; 
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string CarCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _AllCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _AllCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.Id);
                    CarCategory = "Электромобили"; 
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _AllCars.Cars.Where(i => i.Category.CategoryName.Equals("Классические автомобили")).OrderBy(i => i.Id);
                    CarCategory = "Классические автомобили"; 
                }

            }
            var CarObj = new CarsListViewModels
            {
                AllCars = cars,
                CarrCategory = CarCategory
            };

            ViewBag.Title = "Страница с машинками";



            return View(CarObj);
        }                 
    }
}
