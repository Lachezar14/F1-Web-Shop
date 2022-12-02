using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Models;

namespace UnitTests.MockClasses
{
    public class UserDBMock : IUserDB
    {
        public void DropUser(int id)
        {
        }

        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public User GetUser(int id)
        {
            return null;
        }

        public void InsertAdmin(User user)
        {

        }

        public void InsertCustomer(User user)
        {

        }

        public void UpdateUser(User user)
        {

        }
    }
}
