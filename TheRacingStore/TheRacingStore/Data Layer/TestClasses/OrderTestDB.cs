using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Models;

namespace Data_Layer.TestClasses
{
    public class OrderTestDB : IOrderDB
    {
        private List<Order> _orders = new List<Order>();
        public List<Order> Orders { get; set; }

        public void DropOrder(int id)
        {
            Orders.Remove(GetOrder(id));
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            foreach (Order order in Orders)
            {
                orders.Add(order);
            }
            return orders;
        }

        public Order GetOrder(int id)
        {
            foreach (Order order in Orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }

        public Order GetOrder(int userId, int productId)
        {
            foreach (Order order in Orders)
            {
                if (order.User.Id == userId && order.Product.Id == productId)
                {
                    return order;
                }
            }
            return null;
        }

        public void InsertOrder(Order order)
        {
            Orders.Add(order);
        }

        public void OrderShipped(int id)
        {
            int index = Orders.FindIndex(o => o.Id == id);
            if (index >= 0)
            {
                Order order = Orders[index];
                //order.Shipped = 1;
            }
        }
    }
}
