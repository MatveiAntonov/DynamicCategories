using ProductApp.Domain.Entities;

namespace ProductApp.Domain.Interfaces
{
    public interface ICategoryFieldRepository
    {
        Task<IEnumerable<CategoryField?>> GetAllCategoryFields();
        Task<CategoryField?> GetCategoryField(int id);
        Task<bool> CreateCategoryField(CategoryField categoryField);
        Task<bool> DeleteCategoryField(int id);
    }
}
