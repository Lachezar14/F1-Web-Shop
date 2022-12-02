using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Logic_Layer.Interfaces;

namespace Logic_Layer.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDB _orderDB;
        private List<Order> orders;

        public OrderManager(IOrderDB orderDB)
        {
            _orderDB = orderDB;
            orders = _orderDB.GetAllOrders();
        }

        public Order GetOrder(int userId,int productId)
        {
            //Order order = _orderDB.GetOrder(userId,productId);
            foreach (Order order in orders)
            {
                if (order.User.Id == userId && order.Product.Id == productId)
                {
                    return order;
                }
            }
            return null;
        }

        public List<Order> GetAllOrders()
        {
            //List<Order> orders = new List<Order>();
            //orders = _orderDB.GetAllOrders();
            return orders;
        }
        public void AddOrder(Order order)
        {
            orders.Add(order);
            _orderDB.InsertOrder(order);
        }

        public void OrderShipped(int id)
        {
            _orderDB.OrderShipped(id);

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == id)
                {
                    orders[i].Ship();
                }
            }
        }

        public void DeleteOrder(int id)
        {
            _orderDB.DropOrder(id);

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == id)
                {
                   orders.Remove(orders[i]);
                }
            }
        }
    }
}
