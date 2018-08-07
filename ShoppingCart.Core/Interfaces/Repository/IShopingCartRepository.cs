using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces
{
    public interface IShopingCartRepository
    {
        int AddToCart(int prodcutId, string cartId);
        
        List<Cart> GetCartItems(string id);

        decimal GetTotal(string id);

        //void RemoveItem(string removeCartID, int removeProductID);

        //void UpdateItem(string updateCartID, int updateProductID, int quantity);

        //void EmptyCart();

        int GetCount(string id);
    }
}
