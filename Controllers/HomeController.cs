using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _CarRep; 
        

        public HomeController(IAllCars _CarRep)
        {
            this._CarRep = _CarRep;
            
        }
        public ViewResult Index ()
        {
            var homecars = new HomeViewModel { 
                FavCars = _CarRep.GetFavorCars
            };
            return View(homecars); 
        }
    }
}
