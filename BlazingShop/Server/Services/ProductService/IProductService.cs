using BlazingShop.Shared;

namespace BlazingShop.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductsByCategory(string categoryUrl);
    }
}
