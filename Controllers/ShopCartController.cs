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
    public class ShopCartController : Controller
    {
        private readonly IAllCars _CarRep;
        private readonly ShopCart _ShopCart; 

        public ShopCartController (IAllCars _CarRep, ShopCart _ShopCart)
        {
            this._CarRep = _CarRep;
            this._ShopCart = _ShopCart; 
        }
        public ViewResult Index ()
        {
            var items = _ShopCart.GetShopItems();
            _ShopCart.ListShopItems = items; 
            var obj = new ShopCartViewModel
            {
                shopCart = _ShopCart
            };
            return View(obj); 
        }
        public RedirectToActionResult AddToCart (int id)
        {
            var item = _CarRep.Cars.FirstOrDefault(i => i.Id == id); 
            if (item != null)
            {
                _ShopCart.AddToCart(item); 
            }
            return RedirectToAction("Index"); 
        }
    }
}
