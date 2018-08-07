﻿using ShoppingCart.Core;
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
        //public void AddToCart(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void EmptyCart()
        //{
        //    throw new NotImplementedException();
        //}
        
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
        
        //public void RemoveItem(string removeCartID, int removeProductID)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        //{
        //    throw new NotImplementedException();
        //}

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
    }
}
