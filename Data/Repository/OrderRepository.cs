using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart; 
        public OrderRepository (AppDBContent appDBContent, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appDBContent = appDBContent; 
        }
        public void CreateOrder(Order order)
        {
            order.OrderTimeBuyer = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetails = new OrderDetails()
                {
                    CarId = el.car.Id,
                    IdOrder = order.Id,
                    Cost = el.car.Price

                };
                appDBContent.OrderDetails.Add(orderDetails);
            }
            appDBContent.SaveChanges(); 
        }
        
    }
}
