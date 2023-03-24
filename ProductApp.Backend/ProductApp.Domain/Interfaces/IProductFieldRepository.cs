using ProductApp.Domain.Entities;

namespace ProductApp.Domain.Interfaces
{
    public interface IProductFieldRepository
    {
        Task<IEnumerable<ProductField?>> GetAllProductFields();
        Task<ProductField?> GetProductField(int id);
        Task<bool> CreateProductField(ProductField productField);
        Task<bool> DeleteProductField(int id);
    }
}
