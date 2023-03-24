using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Interfaces;

namespace ProductApp.Persistence.Repositories
{
    public class CategoryFieldRepository : ICategoryFieldRepository
    {
        private readonly ProductsDbContext _context;
        public CategoryFieldRepository(ProductsDbContext context)
        {

            _context = context;

        }
        public async Task<IEnumerable<CategoryField?>> GetAllCategoryFields()
        {
            return await _context.CategoryFields
                .Include(cf => cf.Category)
                .ToListAsync();
        }

        public async Task<CategoryField?> GetCategoryField(int id)
        {
            return await _context.CategoryFields
                .Include(cf => cf.Category)
                .FirstOrDefaultAsync(cf => cf.Id == id);
        }

        public async Task<bool> CreateCategoryField(CategoryField categoryField)
        {
            try
            {
                await _context.CategoryFields.AddAsync(categoryField);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryField(int id)
        {
            try
            {
                var entity = await _context.CategoryFields.FirstOrDefaultAsync(cf => cf.Id == id);
                if (entity != null)
                {
                    _context.CategoryFields.Remove(entity);
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
