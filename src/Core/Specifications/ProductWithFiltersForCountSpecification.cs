using Core.Entities;
using Core.RequestFeatures;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductParameters productParameters)
            : base(p => (string.IsNullOrEmpty(productParameters.Search) || p.Name.ToLower().Contains(productParameters.Search))
                        && (!productParameters.BrandId.HasValue || p.BrandId == productParameters.BrandId) 
                        && (!productParameters.CategoryId.HasValue || p.CategoryId == productParameters.CategoryId))
        {
            
        }
    }
}