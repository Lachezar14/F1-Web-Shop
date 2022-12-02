using Models;

namespace Data_Layer.DBConnections
{
    public interface IProductDB
    {
        void DropProduct(int id);
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void InsertClothing(Product product);
        void InsertPoster(Product product);
        void ProductBought(int id);
        void UpdateProduct(Product product);
    }
}