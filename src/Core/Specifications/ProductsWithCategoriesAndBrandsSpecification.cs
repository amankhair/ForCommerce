using System;
using Core.Entities;
using Core.RequestFeatures;

namespace Core.Specifications
{
    public class ProductsWithCategoriesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithCategoriesAndBrandsSpecification(ProductParameters productParameters) 
            : base(p => (string.IsNullOrEmpty(productParameters.Search) || p.Name.ToLower().Contains(productParameters.Search)) 
                        && (!productParameters.BrandId.HasValue || p.BrandId == productParameters.BrandId) 
                        && (!productParameters.CategoryId.HasValue || p.CategoryId == productParameters.CategoryId))
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Brand);
            AddOrderBy((p => p.Name));
            ApplyPaging(productParameters.PageSize * (productParameters.PageIndex - 1), productParameters.PageSize);

            if (!string.IsNullOrEmpty(productParameters.Sort))
            {
                switch (productParameters.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithCategoriesAndBrandsSpecification(Guid id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Brand);
        }
    }
}