using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Logic_Layer.Interfaces;

namespace Logic_Layer.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDB _productDB;
        private List<Product> products;

        public ProductManager(IProductDB productDB)
        {
            _productDB = productDB;
            products = _productDB.GetAllProducts();
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
        public List<Product> GetAllProducts()
        {
            return products;
        }
        public void AddPoster(Product product)
        {
            products.Add(product);
            _productDB.InsertPoster(product);
        }
        public void AddClothing(Product product)
        {
            products.Add(product);
            _productDB.InsertClothing(product);
        }
        public void ProductBought(int id)
        {
            _productDB.ProductBought(id);

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    products[i].DecreaseStock();
                }
            }
        }
        public void UpdateProduct(Product product)
        {

            _productDB.UpdateProduct(product);

            int index = products.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
            {
                products[index] = product;
            }
        }
        public void DeleteProduct(int id)
        {
            products.Remove(GetProduct(id));
            _productDB.DropProduct(id);
        }
    }
}
