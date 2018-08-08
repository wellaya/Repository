using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        ProductContext context = new ProductContext();

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void AddOrderDetails(OrderDetail orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }

        public Order GetPreviousOrder(string userName)
        {
            return context.Orders.FirstOrDefault(x => x.Username == userName);
        }

        public bool IsValidOder(int id , string userName)
        {
            return context.Orders.Any(
                o => o.OrderId == id &&
                o.Username == userName);
        }
    }
}
