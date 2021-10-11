using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly StoreContext _context;
        private IGenericRepository<Brand> _brand;
        private IGenericRepository<Category> _category;
        private IGenericRepository<Product> _product;

        public RepositoryManager(StoreContext context)
        {
            _context = context;
        }

        public IGenericRepository<Brand> Brand
        {
            get
            {
                if (_brand is null)
                    _brand = new GenericRepository<Brand>(_context);

                return _brand;
            }
        }

        public IGenericRepository<Category> Category
        {
            get
            {
                if (_category is null)
                    _category = new GenericRepository<Category>(_context);

                return _category;
            }
        }

        public IGenericRepository<Product> Product
        {
            get
            {
                if (_product is null)
                    _product = new GenericRepository<Product>(_context);

                return _product;
            }
        }
    }
}