using Models;

namespace Data_Layer.DBConnections
{
    public interface IOrderDB
    {
        void DropOrder(int id);
        List<Order> GetAllOrders();
        Order GetOrder(int userId, int productId);        
        void InsertOrder(Order order);
        void OrderShipped(int id);
    }
}