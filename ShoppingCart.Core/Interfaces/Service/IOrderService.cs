using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Core.Interfaces.Service
{
    public interface IOrderService
    {
        Order GetPreviousOrder(string userName);

        Order CreateOrder(Order order, string id);

        bool IsValidOder(int id, string userName);

    }
}
