using AutoMapper;
using Microsoft.Extensions.Configuration;
using MMD_ECommerce.Core.DTOs.Order;
using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Core.Helpers
{
    public class OrderItemResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.Product.PictureUrl) ? $"{_configuration["BaseUrl"]}{source.Product.PictureUrl}" : string.Empty;
        }
    }
}
