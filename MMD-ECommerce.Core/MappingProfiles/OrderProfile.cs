using AutoMapper;
using MMD_ECommerce.Core.DTOs.Order;
using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Core.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress, ShippingAddressDto>().ReverseMap();


            CreateMap<Order, OrderResultDto>()
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.ShippingPrice, opt => opt.MapFrom(src => src.DeliveryMethod.Price))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.SubTotal + src.DeliveryMethod.Price))
                .ReverseMap();

            CreateMap<Order, OrderToCreateDto>()
                .ForMember(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethodId))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemDto>()
                /*.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.orderItemProduct.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.orderItemProduct.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.orderItemProduct.PictureUrl))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemResolver>())*/.ReverseMap();
        }
    }
}
