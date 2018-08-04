using ShoppingCart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core
{
    public class ProductService : IProductService
    {
        IProductRepository db;
        public ProductService(IProductRepository db)
        {

            this.db = db;
        }
        public IEnumerable<Product> GetProducts()
        {
            return db.GetProducts();
        }
    }
}
