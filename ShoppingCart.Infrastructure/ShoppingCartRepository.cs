using ShoppingCart.Core;
using ShoppingCart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class ShoppingCartRepository : IShopingCartRepository
    {
        ProductContext context = new ProductContext();
                
        public List<Cart> GetCartItems(string id)
        {
            return context.Carts.Where(
               cart => cart.CartId == id).ToList();
        }

        public decimal GetTotal(string id)
        {
            decimal? total = (from cartItems in context.Carts
                              where cartItems.CartId == id
                              select (int?)cartItems.Count *
                              cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int RemoveItem(string removeCartID, int removeProductID)
        {

            var cartItem = context.Carts.Single(
                cart => cart.CartId == removeCartID
                && cart.ProductId == removeProductID);


            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    context.Carts.Remove(cartItem);
                }
                // Save changes
                context.SaveChanges();
            }
            return itemCount;
        }
        
        public int GetCount(string id)
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in context.Carts
                          where cartItems.CartId == id
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        public int AddToCart(int prodcutId, string cartId)
        {
            var cartItem = context.Carts.SingleOrDefault(
                c => c.CartId == cartId
                && c.ProductId == prodcutId);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    CartId = cartId,
                    ProductId = prodcutId,
                    DateCreated = DateTime.Now,
                    Count = 1
                };
                context.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            context.SaveChanges();

            return cartItem.Count;
        }

        public void EmptyCart(string id)
        {
            var cartItems = context.Carts.Where(
                cart => cart.CartId == id);

            foreach (var cartItem in cartItems)
            {
                context.Carts.Remove(cartItem);
            }
            // Save changes
            context.SaveChanges();
        }
    }
}
