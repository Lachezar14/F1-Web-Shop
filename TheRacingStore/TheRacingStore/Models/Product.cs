//using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; private set; }
        public int Stock { get; private set;}
        public decimal Price { get; protected set; }
        public string Type { get; private set; }

        public Product(int id,string desc,int stock,decimal price,string type) 
        {
            this.Id = id;
            this.Description = desc;
            this.Stock = stock;
            this.Price = price;
            this.Type = type;
        }

        public Product(string desc, int stock, decimal price,string type)
        {
            this.Description = desc;
            this.Stock = stock;
            this.Price = price;
            this.Type = type;
        }

        public Product() { }

        public virtual void Discount(){}

        public void DecreaseStock()
        {
            this.Stock--;
        }

        public override string ToString()
        {
            return $"{Type} : {Description} | Stock:{Stock} | Price:{Price}";
        }

        public override bool Equals(Object obj)
        {
            if (obj is Product)
            {
                var that = obj as Product;
                return this.Id == that.Id;
            }
            return false;
        }
    }
}
