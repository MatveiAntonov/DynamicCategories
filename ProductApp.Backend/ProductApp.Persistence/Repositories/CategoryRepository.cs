using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Interfaces;

namespace ProductApp.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ProductsDbContext _context;
        public CategoryRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category?>> GetAllCategories()
        {
            return await _context.Categories
                .Include(c => c.CategoryFields)
                .ToListAsync();
        }
        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories
                .Include(c => c.CategoryFields)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> CreateCategory(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (entity != null)
                {
                    _context.Categories.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
