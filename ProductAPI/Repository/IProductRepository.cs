using ProductAPI.Models;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> Add(Product product); 
        Task<Product> Update(Product product);
        bool Delete(int id);
    }
}
