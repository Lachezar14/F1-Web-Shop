using Models;

namespace Data_Layer.DBConnections
{
    public interface IUserDB
    {
        void DropUser(int id);
        List<User> GetAllUsers();
        User GetUser(int id);
        void InsertAdmin(User user);
        void InsertCustomer(User user);
        void UpdateUser(User user);
    }
}