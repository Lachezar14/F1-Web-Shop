using Models;

namespace Logic_Layer.Interfaces
{
    public interface IUserManager
    {
        void AddNewAdmin(User user);
        void AddNewCustomer(User user);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUser(int id);
        User GetUserByLogin(string username, string password);
        void UpdateUser(User user);
    }
}