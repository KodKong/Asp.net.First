using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller 
    {
        private readonly IAllOrders OrdersInterface;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders OrdersInterface, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.OrdersInterface = OrdersInterface;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();
            if(shopCart.ListShopItems.Count==0)
            {
                ModelState.AddModelError("","Добавьте товары"); 
            }
            if(ModelState.IsValid)
            {
                OrdersInterface.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ обработан";
            return View(); 
        }
    }
}
