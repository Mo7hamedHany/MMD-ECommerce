using AutoMapper;
using MMD_ECommerce.Core.DTOs.Basket;
using MMD_ECommerce.Data.Models.Basket;

namespace MMD_ECommerce.Core.MappingProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<Basket, BasketToCreateDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemToCreateDto>().ReverseMap();
        }
    }
}
