using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces
{
    public interface IShoppingCartRepository
    {
        void AddToCart(int id);
        string GetCartId();

        List<CartItem> GetCartItems();

        decimal GetTotal();

        void RemoveItem(string removeCartID, int removeProductID);

        void UpdateItem(string updateCartID, int updateProductID, int quantity);

        void EmptyCart();
    }
}
