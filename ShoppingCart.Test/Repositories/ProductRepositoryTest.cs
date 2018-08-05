using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Core;
using ShoppingCart.Infrastructure;
using System.Linq;


namespace ShoppingCart.Test.Repositories
{
    [TestClass]
    public class ProductRepositoryTest
    {
        ProductRepository Repo;
        [TestInitialize]
        public void TestSetup()
        {
            ProductInitalizeDB db = new ProductInitalizeDB();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new ProductRepository();
        }

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            var result = Repo.GetProducts();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(16, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsProduct()
        {
            Product productToInsert = new Product
            {
                Id = 3,
                inStock = true,
                Name = "Salt",
                Price = 17

            };
            Repo.Add(productToInsert);
            // If Product inserts successfully, 
            //number of records will increase to 3 
            var result = Repo.GetProducts();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }
    }
}
