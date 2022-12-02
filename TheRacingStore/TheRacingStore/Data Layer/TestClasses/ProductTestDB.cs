using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Models;

namespace Data_Layer.TestClasses
{
    /*public class ProductTestDB : IProductDB
    {
        private List<Product> products = new List<Product>();
        public List<Product> Products { get; set; }
        public void DropProduct(int id)
        {
            Products.Remove(GetProduct(id));
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            foreach (Product product in products)
            {
                products.Add(product);
            }
            return products;
        }

        public Product GetProduct(int id)
        {            
            foreach (Product product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public void InsertClothing(Clothing clothing)
        {
            products.Add(clothing);
        }
        public void InsertPoster(Poster poster)
        {
            products.Add(poster);
        }
        /*public void InsertProduct(Product product)
        {
            Products.Add(product);
        }

        public void ProductBought(int id)
        {
            foreach (Product product in Products)
            {
                //product.Stock -= 1;
            }
        }

        public void UpdateProduct(Product product)
        {
            int index = products.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
            {
                products[index] = product;
            }
        }
    }*/
}
