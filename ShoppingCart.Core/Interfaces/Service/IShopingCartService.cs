using ShoppingCart.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Core.Interfaces
{
    public interface IShopingCartService
    {
        ShoppingCartRemoveViewModel AddToCart(int productId, string cartId);
        string GetCartId(HttpContextBase context);
        ShoppingCartViewModel GetCart(string id);
        //List<CartItem> GetCartItems();
        int GetCount(string id);
        //decimal GetTotal(string id);
        ShoppingCartRemoveViewModel RemoveItem(string removeCartID, int removeProductID);
        //void UpdateItem(string updateCartID, int updateProductID, int quantity);
        //void EmptyCart();
        
    }
}
