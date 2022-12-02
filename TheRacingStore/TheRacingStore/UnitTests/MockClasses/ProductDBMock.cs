using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Models;

namespace UnitTests.MockClasses
{
    public class ProductDBMock : IProductDB
    {

        public void DropProduct(int id)
        {
            
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>();
        }
        
        public Product GetProduct(int id)
        {
            return null;
        }

        public void InsertClothing(Product product)
        {
            
        }

        public void InsertPoster(Product product)
        {
           
        }

        public void ProductBought(int id)
        {
        }
        
        public void UpdateProduct(Product product)
        {
           
        }
    }
}
