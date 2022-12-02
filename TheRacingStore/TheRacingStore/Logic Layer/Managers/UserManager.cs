using Data_Layer.DBConnections;
using Logic_Layer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.TestClasses;

namespace Logic_Layer.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserDB _userDB;
        private readonly List<User> users;
       
        public UserManager(IUserDB userDB)
        {
            _userDB = userDB;
            users = _userDB.GetAllUsers();
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

        public User GetUserByLogin(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public void AddNewCustomer(User user)
        {
            users.Add(user);
            _userDB.InsertCustomer(user);
        }
        public void AddNewAdmin(User user)
        {
            users.Add(user);
            _userDB.InsertAdmin(user);
        }

        public void UpdateUser(User user)
        {
            _userDB.UpdateUser(user);
            
            int index = users.FindIndex(u => u.Id == user.Id);
            if (index >= 0)
            {
                users[index] = user;
            }
        }

        public void DeleteUser(int id)
        {
            users.Remove(GetUser(id));
            _userDB.DropUser(id);
        }


    }
}
