using Microsoft.Extensions.Configuration;
using MMD_ECommerce.Data.Models;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public ProductService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<bool> BrandExists(int id)
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAsync(id);

            if (brands is null) return false;

            return true;
        }

        public async Task<bool> CategoryExists(int id)
        {
            var categories = await _unitOfWork.Repository<Category, int>().GetAsync(id);

            if (categories is null) return false;

            return true;
        }

        public async Task<string> CreateProduct(Product product)
        {
            if (product == null) return "Bad Request";

            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            if (product.PictureUrl is null)
            {
                product.PictureUrl = Defaults.ProductPicture;
            }
            else
            {
                product.PictureUrl = $"{_configuration["PicUrl"]}{product.PictureUrl}";
            }
            await _unitOfWork.Repository<Product, int>().AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<string> DeleteProduct(int id)
        {

            var product = await _unitOfWork.Repository<Product, int>().GetAsync(id);
            if (product == null) return "NotFound";

            _unitOfWork.Repository<Product, int>().Delete(product);
            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<string> EditProduct(Product product)
        {
            var existingProduct = await _unitOfWork.Repository<Product, int>().GetAsync(product.Id);
            if (existingProduct == null) return "NotFound";

            _unitOfWork.Repository<Product, int>().Detach(existingProduct);

            product.UpdatedAt = DateTime.Now;

            _unitOfWork.Repository<Product, int>().Update(product);
            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<Product> GetProduct(int id)
        {
            var specs = new ProductSpecifications(id);
            var products = await _unitOfWork.Repository<Product, int>().GetWithSpecsAsync(specs);

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsOfMerchant(string email)
        {
            var specs = new ProductSpecifications(email);
            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecsAsync(specs);

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsWithSpecs(ProductSpecificationParameters parameters)
        {
            var specs = new ProductSpecifications(parameters);
            return await _unitOfWork.Repository<Product, int>().GetAllWithSpecsAsync(specs);
        }

        public async Task<bool> TypeExists(int id)
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAsync(id);

            if (types is null) return false;

            return true;
        }
    }
}
