using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<IReadOnlyList<Brand>> GetBrandsAsync();
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}