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
        IProductRepository repository;
        public ProductService(IProductRepository repository)
        {

            this.repository = repository;
        }

        public void Add(Product p)
        {
            repository.Add(p);
        }

        public void Edit(Product p)
        {
            repository.Edit(p);
        }

        public Product FindById(int Id)
        {
            return repository.FindById(Id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return repository.GetProducts();
        }

        public IEnumerable<Product> ReadProductData()
        {
            return repository.ReadProductData();
        }

        public void Remove(int Id)
        {
            repository.Remove(Id);
        }

        public void WriteFile()
        {
            repository.WriteFile();
        }
    }
}
