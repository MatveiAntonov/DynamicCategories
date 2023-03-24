using ProductApp.Domain.Entities;

namespace ProductApp.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetAllProducts();
        Task<Product?> GetProduct(int id);
        Task<bool> CreateProduct(Product product);
        Task<bool> DeleteProduct(int id);

    }
}
