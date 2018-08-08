using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using ShoppingCart.Core;
using ShoppingCart.Core.Models;

namespace ShoppingCart.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext()
           : base("name=ProductAppConnectionString")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
} 
   