using ProductApp.Domain.Entities;

namespace ProductApp.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category?>> GetAllCategories();
        Task<Category?> GetCategory(int id);
        Task<bool> CreateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
