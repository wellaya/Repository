using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Core
{
    public class ShopingCartService : IShopingCartService
    {
        IShopingCartRepository cartRepository;
        IProductRepository productRepository;
        public const string CartSessionKey = "CartId";

        public ShopingCartService(IShopingCartRepository cartRepository, IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }
        
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public List<Cart> GetCartItems(string id)
        {
            return cartRepository.GetCartItems(id);
        }

        public ShoppingCartRemoveViewModel RemoveItem(string removeCartID, int removeProductID)
        {
            ShoppingCartRemoveViewModel viewModel = new ShoppingCartRemoveViewModel();
            viewModel.ItemCount = cartRepository.RemoveItem(removeCartID, removeProductID);
            var removedItem = productRepository.FindById(removeProductID);
            viewModel.Message = "One (1) " + removedItem.Name +" has been removed from your shopping cart.";
            viewModel.DeleteId = removeProductID;
            viewModel.CartCount = cartRepository.GetCount(removeCartID);
            viewModel.CartTotal = cartRepository.GetTotal(removeCartID);
            return viewModel;
        }
        
        public ShoppingCartViewModel GetCart(string id)
        {
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
            viewModel.CartItems = cartRepository.GetCartItems(id);
            viewModel.CartTotal = cartRepository.GetTotal(id);
            return viewModel;
        }
        
        public int GetCount(string id)
        {
            return this.cartRepository.GetCount(id);
        }
        public ShoppingCartRemoveViewModel AddToCart(int productId, string cartId)
        {
            ShoppingCartRemoveViewModel viewModel = new ShoppingCartRemoveViewModel();
            viewModel.ItemCount = cartRepository.AddToCart(productId, cartId);
            var addedItem = productRepository.FindById(productId);
            viewModel.Message = addedItem.Name + " has been added to your shopping cart.";
            viewModel.DeleteId = productId;
            viewModel.CartCount = cartRepository.GetCount(cartId);
            viewModel.CartTotal = cartRepository.GetTotal(cartId);
            return viewModel;
        }

        public void EmptyCart(string id)
        {
            this.cartRepository.EmptyCart(id);
        }
    }
}
