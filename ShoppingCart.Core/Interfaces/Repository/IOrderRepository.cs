using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Order GetPreviousOrder(string userName);
        void AddOrder(Order order);
        void AddOrderDetails(OrderDetail orderDetail);
        bool IsValidOder(int id, string userName);
    }
}
