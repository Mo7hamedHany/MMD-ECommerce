using AutoMapper;
using MMD_ECommerce.Core.DTOs.Categories;
using MMD_ECommerce.Data.Models.Products;

namespace MMD_ECommerce.Core.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryToCreateDto, Category>();
        }

    }
}
