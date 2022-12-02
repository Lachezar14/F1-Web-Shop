using Models;

namespace Logic_Layer.Interfaces
{
    public interface IProductManager
    {
        //void AddProduct(Product product);
        void AddClothing(Product product);
        void AddPoster(Product product);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void ProductBought(int id);
        void UpdateProduct(Product product);
    }
}