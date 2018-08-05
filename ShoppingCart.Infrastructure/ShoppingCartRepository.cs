using ShoppingCart.Core;
using ShoppingCart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public void AddToCart(int id)
        {
            throw new NotImplementedException();
        }

        public void EmptyCart()
        {
            throw new NotImplementedException();
        }

        public string GetCartId()
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
