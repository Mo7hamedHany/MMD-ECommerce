using MMD_ECommerce.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Specifications.Products
{
    public class ProductCountSpecifications : BaseSpecification<Product>
    {
        public ProductCountSpecifications(ProductSpecificationParameters parameters)
           : base(product =>
           (!parameters.TypeId.HasValue || parameters.TypeId.Value == product.TypeId) &&
           (!parameters.BrandId.HasValue || parameters.BrandId.Value == product.BrandId) &&
            (string.IsNullOrEmpty(parameters.Search) || product.Name.Contains(parameters.Search)))
        {

        }
    }
}
