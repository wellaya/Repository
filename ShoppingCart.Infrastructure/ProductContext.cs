using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using ShoppingCart.Core;

namespace ShoppingCart.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext()
           : base("name=ProductAppConnectionString")
        {
        }
        public DbSet<Product> Products { get; set; }
    }
} 
   