using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Models;

namespace UnitTests.MockClasses
{
    public class OrderDBMock : IOrderDB
    {
        private Order order = new Order();

        public void DropOrder(int id)
        {

        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>();
        }

        public Order GetOrder(int userId, int productId)
        {
            return null;
        }

        public void InsertOrder(Order order)
        {
            
        }

        public void OrderShipped(int id)
        {

        }
    }
}
