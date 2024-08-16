using WebApplicationDemo.Models;

namespace WebApplicationDemo.DAO
{
    public interface IProductDao
    {
        Task<int> InsertProduct(Product p);
        Task<int> UpdatePriceById(int id,decimal newPrice);
        Task<int> DeleteById(int id);
        Task<List<Product>> GetProducts();
        Task<List<Product>> SortProductsByPrice();
        Task<List<Product>> GetProductsByPriceRange(decimal min, decimal max);
        Task<int> GetTotalProductsCount();
        Task<Product> GetProductById(int id);
    }
}
