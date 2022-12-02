using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Logic_Layer.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using UnitTests.MockClasses;

namespace UnitTests.TestEnvironment
{
    [TestClass]
    public class ProductManagerTesting
    {
        private readonly IProductDB _productDB;
        private ProductManager _productManager;

        public ProductManagerTesting()
        {
            _productDB = new ProductDBMock();
            _productManager = new ProductManager(_productDB);
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            Product product1 = new Clothing(2, "bla", 1, 10, "Clothing", "S");
            Product product2 = new Poster(3, "bla", 1, 10, "Poster", 100, 200);
            
            List<Product> expected = new List<Product>();
            
            expected.Add(product1);
            expected.Add(product2);
            
            _productManager.AddClothing(product1);
            _productManager.AddPoster(product2);
            
            List<Product> actual = _productManager.GetAllProducts();
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetProductTest()
        {
            Product expected = new Clothing(2, "bla", 1, 10, "Clothing", "S");
            _productManager.AddClothing(expected);
            
            Product actual = _productManager.GetProduct(2);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AddClothingTest()
        {
            Product expected = new Clothing(2, "bla", 1, 10, "Clothing", "S");
            
            _productManager.AddClothing(expected);
            Product actual = _productManager.GetProduct(2);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AddPosterTest()
        {
            Product expected = new Poster(3, "bla", 1, 10, "Poster", 100,200);
            _productManager.AddPoster(expected);
            
            Product actual = _productManager.GetProduct(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductBoughtTest()
        {
            Product product = new Poster(3, "bla", 2, 10, "Poster", 100, 200);
            _productManager.AddPoster(product);
            _productManager.ProductBought(3);
            Assert.AreEqual(1,product.Stock);
        }
        
        [TestMethod]
        public void UpdateProductTest()
        {
            Product productOld = new Poster(1, "bla", 2, 5, "Poster",100,250);
            Product productNew = new Poster(1, "desc", 10, 16, "Poster",150,200);
            
            _productManager.AddPoster(productOld);
            _productManager.UpdateProduct(productNew);
            
            Product actual = _productManager.GetProduct(1);
            Assert.AreEqual(productNew, actual);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            Product product = new Clothing(1, "bla", 2, 5, "Clothing", "S");
            _productManager.AddClothing(product);
            _productManager.DeleteProduct(1);
            var actual = _productManager.GetProduct(1);
            Assert.IsNull(actual);
        }
    }
}
