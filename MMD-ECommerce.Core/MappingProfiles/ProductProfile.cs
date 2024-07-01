using AutoMapper;
using MMD_ECommerce.Core.DTOs.Product;
using MMD_ECommerce.Core.Features.Products.Query.Models;
using MMD_ECommerce.Core.Helpers;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Specifications.Products;

namespace MMD_ECommerce.Core.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
    .ForMember(d => d.BrandName, o => o.MapFrom(s => s.ProductBrand.Name))
    .ForMember(d => d.TypeName, o => o.MapFrom(s => s.ProductType.Name))
    .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
    .ForMember(d => d.PictureUrl, o => o.MapFrom<PictureUrlResolver>()).ReverseMap();

            CreateMap<GetProductsQuery, ProductSpecificationParameters>();

            CreateMap<Product, ProductToCreateDto>()
                .ForMember(dest => dest.PictureName, opt => opt.MapFrom(src => src.PictureUrl))
    .ReverseMap();

            CreateMap<ProductToEditDto, Product>()
.ReverseMap();
        }
    }
}
