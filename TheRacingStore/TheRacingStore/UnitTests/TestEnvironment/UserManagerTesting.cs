using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Data_Layer.DBConnections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Logic_Layer.Managers;
using UnitTests.MockClasses;

namespace UnitTests.TestEnvironment
{
    [TestClass]
    public class UserManagerTesting
    {
        private readonly UserManager _userManager;

        public UserManagerTesting()
        {
            IUserDB _userDB;
            _userDB = new UserDBMock();
            _userManager = new UserManager(_userDB);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var expected = new User(1, "bla", "bla", "bla@g.com", "32434453141", "bla", "bla", "6054", "Customer", "bla", "bla");
            _userManager.AddNewCustomer(expected);
            var actual = _userManager.GetUser(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserByLoginTest()
        {
            var expected = new User(1, "bla", "bla", "bla@g.com", "32434453141", "bla", "bla", "6054", "Customer", "bla", "bla");
            _userManager.AddNewCustomer(expected);
            var actual = _userManager.GetUserByLogin(expected.Username, expected.Password);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetAllUsersTest()
        {
            User user1 = new User(1, "bla", "bla", "bla@g.com", "32434453141", "bla", "bla", "6054", "Customer", "bla", "bla");
            User user2 = new User(2, "doll", "en", "bla@g.com", "32434453141", "bla", "bla", "6054", "Customer", "didi", "didi");
            
            List<User> expected = new List<User>();
            expected.Add(user1);
            expected.Add(user2);
            
            _userManager.AddNewCustomer(user1);
            _userManager.AddNewCustomer(user2);
            
            List<User> actual = _userManager.GetAllUsers();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNewCustomerTest()
        {
            User expected = new User(4, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "Customer", "bla", "bla");
            _userManager.AddNewCustomer(expected);
            User actual = _userManager.GetUser(4);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddNewAdminTest()
        {
            User expected = new User(5, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "Admin", "bla", "bla");
            _userManager.AddNewAdmin(expected);
            User actual = _userManager.GetUser(5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            User user = new User(4, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "Admin", "bla", "bla");
            _userManager.AddNewCustomer(user);
            _userManager.DeleteUser(4);
            Assert.IsNull(_userManager.GetUser(4));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            User userOld = new User(4, "bla", "bla", "bla", "bla", "bla", "bla", "bla", "Admin", "bla", "bla");
            _userManager.AddNewCustomer(userOld);
            User userNew = new User(4, "john", "doe", "bla", "bla", "bla", "bla", "bla", "Admin", "bla", "bla");
            _userManager.UpdateUser(userNew);
            User actual = _userManager.GetUser(4);
            Assert.AreEqual(userNew, actual);
        }
    }

}