using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using MMD_ECommerce.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductsWithSpecs(ProductSpecificationParameters parameters)
        {
            var specs = new ProductSpecifications(parameters);
            return await _unitOfWork.Repository<Product, int>().GetAllWithSpecsAsync(specs);
        }
    }
}
