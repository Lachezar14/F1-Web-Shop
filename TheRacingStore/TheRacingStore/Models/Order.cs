//using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        private Product product;
        private User user;

        public int Id { get; set; }
        public Product Product => product; // => syntax equal to get { return product; } 
        public User User => user; // => syntax equal to get { return user; } 
        public int Shipped { get; private set; }

        public Order(Product product, User user, int shipped)
        {
            this.product = product;
            this.user = user;
            Shipped = shipped;
        }
        
        public Order(int id,Product product, User user, int shipped)
        {
            Id = id;
            this.product = product;
            this.user = user;
            Shipped = shipped;
        }

        public Order() 
        {
        }

        public void Ship()
        {
            Shipped = 1;
        }
        
        public override string ToString()
        {
            return $"ID:{Id}, Product ID:{product.Id}, Revenue:{product.Price} | Client:{user.FName} {user.LName}, Address:{user.Address}";
        }
    }
}
