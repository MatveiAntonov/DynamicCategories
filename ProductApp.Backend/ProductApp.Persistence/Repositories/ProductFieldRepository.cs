using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Interfaces;

namespace ProductApp.Persistence.Repositories
{
    public class ProductFieldRepository : IProductFieldRepository
    {
        private readonly ProductsDbContext _context;
        public ProductFieldRepository(ProductsDbContext context)
        {

            _context = context;

        }

        public async Task<IEnumerable<ProductField?>> GetAllProductFields()
        {
            return await _context.ProductFields
                .Include(pf => pf.Product)
                .ToListAsync();
        }

        public async Task<ProductField?> GetProductField(int id)
        {
            return await _context.ProductFields
                .Include(pf => pf.Product)
                .FirstOrDefaultAsync(cf => cf.Id == id);
        }

        public async Task<bool> CreateProductField(ProductField productField)
        {
            try
            {
                await _context.ProductFields.AddAsync(productField);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteProductField(int id)
        {
            try
            {
                var entity = await _context.ProductFields.FirstOrDefaultAsync(pf => pf.Id == id);
                if (entity != null)
                {
                    _context.ProductFields.Remove(entity);
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
