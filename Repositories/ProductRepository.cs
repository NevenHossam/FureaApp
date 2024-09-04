using System.Linq.Expressions;
using FureaApp.Data;
using FureaApp.Entities;
using FureaApp.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FureaApp.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _context.Products.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> Where(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.Where(predicate).ToListAsync();
        }

        public async Task Create(Product obj)
        {
            await _context.Products.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Product obj)
        {
            var existingProduct = await _context.Products.Where(p => p.Id == obj.Id).FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                existingProduct.Name = obj.Name;
                existingProduct.Description = obj.Description;
                existingProduct.Price = obj.Price;
                existingProduct.SubCategoryId = obj.SubCategoryId;

                _context.Entry(existingProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}