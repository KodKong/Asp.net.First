using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }

        public List <ShopCartitem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contex = service.GetService<AppDBContent>();
            string ShopCartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", ShopCartId);
            return new ShopCart(contex) { ShopCartId = ShopCartId }; 
        }

        public void AddToCart (Car car)
        {
            this.appDBContent.ShopCarItem.Add(new ShopCartitem
            {
                ShopCartId = ShopCartId,
                car = car, 
                Price = car.Price

            }) ;
            appDBContent.SaveChanges(); 
        }

        public List<ShopCartitem> GetShopItems ()
        {
            return appDBContent.ShopCarItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList(); 
        }
    }
}
