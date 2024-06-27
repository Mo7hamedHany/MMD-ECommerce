using AutoMapper;
using Microsoft.Extensions.Configuration;
using MMD_ECommerce.Core.DTOs.Product;
using MMD_ECommerce.Data.Models.Products;

namespace MMD_ECommerce.Core.Helpers
{
    public class ProductToCreatePicResolver : IValueResolver<ProductToCreateDto, Product, string>
    {
        private readonly IConfiguration _configuration;

        public ProductToCreatePicResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(ProductToCreateDto source, Product destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.PictureName) ? $"{_configuration["PicUrl"]}{source.PictureName}" : string.Empty;
        }
    }
}
