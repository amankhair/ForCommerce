using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync() =>
            await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();

        public async Task<Product> GetProductByIdAsync(Guid productId) =>
            await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == productId);

        public async Task<IReadOnlyList<Brand>> GetBrandsAsync() =>
            await _context.Brands.ToListAsync();

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync() =>
            await _context.Categories.ToListAsync();
    }
}