using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Specifications
{
    public class ProductSpecifications : BaseSpecification<Product>
    {
        public ProductSpecifications(ProductSpecificationParameters parameters)
            : base(product =>
            (!parameters.TypeId.HasValue || parameters.TypeId.Value == product.TypeId) &&
            (!parameters.BrandId.HasValue || parameters.BrandId.Value == product.BrandId) &&
            (!parameters.CategoryId.HasValue || parameters.CategoryId.Value == product.CategoryId) &&
            (string.IsNullOrEmpty(parameters.Search) || product.Name.Contains(parameters.Search)))
        {
            IncludeExpressions.Add(product => product.ProductType);
            IncludeExpressions.Add(product => product.ProductBrand);
            IncludeExpressions.Add(product => product.Category);

            ApplyPagination(parameters.PageSize, parameters.PageIndex);

            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSpecificationEnum.NameAsc:
                        OrderBy = x => x.Name;
                        break;
                    case ProductSpecificationEnum.NameDesc:
                        OrderByDesc = x => x.Name;
                        break;
                    case ProductSpecificationEnum.PriceAsc:
                        OrderBy = x => x.Price;
                        break;
                    case ProductSpecificationEnum.PriceDesc:
                        OrderByDesc = x => x.Price;
                        break;
                    default:
                        OrderBy = x => x.Name;
                        break;
                }
            }
            else
            {
                OrderBy = x => x.Name;
            }
        }

        public ProductSpecifications(int id)
            : base(product => product.Id == id)
        {
            IncludeExpressions.Add(product => product.ProductType);
            IncludeExpressions.Add(product => product.ProductBrand);
        }
    }
}
