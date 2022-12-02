using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DBConnections;
using Models;

namespace Data_Layer.TestClasses
{   public class UserTestDB : IUserDB
    {
        private List<User> users = new List<User>();
        //public List<User> Users { get; set; }

        public void DropUser(int id)
        {
            users.Remove(GetUser(id));
        }

        public List<User> GetAllUsers()
        {
            List<User> _users = new List<User>();
            foreach (User user in users)
            {
                _users.Add(user);
            }
            return _users;
        }

        public User GetUser(int id)
        {
            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public void InsertAdmin(User user)
        {
            users.Add(user);
        }

        public void InsertCustomer(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            int index = users.FindIndex(u => u.Id == user.Id);
            if (index >= 0)
            {
                users[index] = user;
            }
        }
    }
}
