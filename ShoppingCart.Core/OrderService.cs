using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Interfaces.Service;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Core
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        IShopingCartRepository shopingCartRepository;
        public OrderService(IOrderRepository orderRepository, IShopingCartRepository shopingCartRepository)
        {
            this.orderRepository = orderRepository;
            this.shopingCartRepository = shopingCartRepository;
        }

        public Order CreateOrder(Order order, string id)
        {
            this.orderRepository.AddOrder(order);
            decimal orderTotal = 0;
            order.OrderDetails = new List<OrderDetail>();
            var cartItems = this.shopingCartRepository.GetCartItems(id);
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Product.Price);
                order.OrderDetails.Add(orderDetail);
                this.orderRepository.AddOrderDetails(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Empty the shopping cart
            this.shopingCartRepository.EmptyCart(id);
            // Return the OrderId as the confirmation number
            return order;
        }

        public Order GetPreviousOrder(string userName)
        {
            return this.orderRepository.GetPreviousOrder(userName);
        }

        public bool IsValidOder(int id, string userName)
        {
            return this.orderRepository.IsValidOder(id,userName);
        }
    }
}
