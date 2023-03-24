using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Interfaces;

namespace ProductApp.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _context;
        public ProductRepository(ProductsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product?>> GetAllProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductFields)
                .ToListAsync();
        }
        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductFields)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            } 
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (entity != null)
                {
                    _context.Products.Remove(entity);
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
