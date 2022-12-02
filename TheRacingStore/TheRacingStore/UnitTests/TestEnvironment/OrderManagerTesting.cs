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
    public class OrderManagerTesting
    {
        //private readonly IOrderDB _orderDB;
        private readonly OrderManager _orderManager;

        public OrderManagerTesting()
        {
            IOrderDB _orderDB;
            _orderDB = new OrderDBMock();
            _orderManager = new OrderManager(_orderDB);
        }
        
        [TestMethod]
        public void GetOrderTest()
        {
            User user = new User(1, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "Customer", "bla", "bla");
            Product product = new Clothing(1,"bla",10,10,"Clothing","S");
            Order expected = new Order(product,user,0);
            
            _orderManager.AddOrder(expected);
            
            Order actual = _orderManager.GetOrder(1,1);
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetAllOrdersTest()
        {
            User user1 = new User(1, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "Customer", "bla", "bla");
            Product product1 = new Clothing(1, "bla", 10, 10, "Clothing", "S");
            Order order1 = new Order(product1, user1, 0);
            
            User user2 = new User(2, "john", "doe", "bla", "bla", "bla", "bla", "bla", "Customer", "bla", "bla");
            Product product2 = new Poster(2, "bla", 10, 10, "Poster", 100,250);
            Order order2 = new Order(product2, user2, 0);
            
            List<Order> expected = new List<Order>();
            expected.Add(order1);
            expected.Add(order2);
            
            _orderManager.AddOrder(order1);
            _orderManager.AddOrder(order2);
            
            List<Order> actual = _orderManager.GetAllOrders();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddOrderTest()
        {
            User user = new User(2,"bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla");
            Product product = new Product(2, "bla", 1, 1, "bla");
            Order expected = new Order(product,user,0);
            
            _orderManager.AddOrder(expected);
            
            Order actual = _orderManager.GetOrder(2, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            User user = new User(2, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla");
            Product product = new Product(2, "bla", 1, 1, "bla");
            Order expected = new Order(product, user, 0);
            

            _orderManager.AddOrder(expected);
            _orderManager.DeleteOrder(0);

            Order actual = _orderManager.GetOrder(2, 2);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void OrderShippedTest()
        {
            User user = new User(2, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla", "bla");
            Product product = new Product(2, "bla", 1, 1, "bla");
            Order order = new Order(product, user, 0);
            
            order.Id = 1;
            
            _orderManager.AddOrder(order);
            _orderManager.OrderShipped(order.Id);
            
            Assert.AreEqual(1, order.Shipped);
        }
    }
}
