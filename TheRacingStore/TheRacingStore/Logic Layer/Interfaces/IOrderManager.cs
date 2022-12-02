using Models;

namespace Logic_Layer.Interfaces
{
    public interface IOrderManager
    {
        void AddOrder(Order order);
        void DeleteOrder(int id);
        List<Order> GetAllOrders();
        Order GetOrder(int userId,int productId);
        void OrderShipped(int id);
    }
}
