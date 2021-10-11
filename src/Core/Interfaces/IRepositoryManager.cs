using Core.Entities;

namespace Core.Interfaces
{
    public interface IRepositoryManager
    {
        IGenericRepository<Brand> Brand { get; }
        IGenericRepository<Category> Category { get; }
        IGenericRepository<Product> Product { get; }
    }
}