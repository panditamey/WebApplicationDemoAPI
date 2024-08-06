using WebApplicationDemo.Models;

namespace WebApplicationDemo.Data
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();

        public Task<Product?> GetProductById(int id);
        public Task<List<Product?>> GetProductsByName(string name);
        public Task<List<Product?>> GetProductsByCategory(string category);
        public Task<Product?> GetProductByProductCode(string code);
        public Task<List<Product?>> GetProductsByRating(double rating);
        public Task<List<Product?>> GetProductsByPriceRange(double min,double max);

        public  Task<Product?> UpdateProductPrice(int id, double newPrice);

        public  Task<bool> CreateProduct(Product product);
        public  Task<bool> DeleteProduct(int id);

    }
}
