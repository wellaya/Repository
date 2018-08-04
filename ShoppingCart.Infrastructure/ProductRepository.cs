using ShoppingCart.Core;
using ShoppingCart.Core.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace ShoppingCart.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        ProductContext context = new ProductContext();
        public void Add(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public void Edit(Product p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Product FindById(int Id)
        {
            var result = (from r in context.Products where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public void Remove(int Id)
        {
            Product p = (Product)context.Products.Find(Id);
            context.Products.Remove(p);
            context.SaveChanges();

        }

        public IEnumerable<Product> ReadProductData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\Priyantha\\Desktop\\SC\\ShoppingCart\\product.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/root/Brand");
            string proID = "", proName = "", price = "";
            foreach (XmlNode node in nodeList)
            {
                proID = node.SelectSingleNode("Product_id").InnerText;
                proName = node.SelectSingleNode("Product_name").InnerText;
                price = node.SelectSingleNode("Product_price").InnerText;
            }
            return new List<Product>();
        }
    }
}
