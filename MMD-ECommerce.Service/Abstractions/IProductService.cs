using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsWithSpecs(ProductSpecificationParameters parameters);
    }
}
