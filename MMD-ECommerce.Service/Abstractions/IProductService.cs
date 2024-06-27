using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Specifications.Products;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsWithSpecs(ProductSpecificationParameters parameters);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProductsOfMerchant(string email);
        Task<string> CreateProduct(Product product);
        Task<string> EditProduct(Product product);
        Task<string> DeleteProduct(int id);
        Task<bool> BrandExists(int id);
        Task<bool> TypeExists(int id);
        Task<bool> CategoryExists(int id);
    }
}
