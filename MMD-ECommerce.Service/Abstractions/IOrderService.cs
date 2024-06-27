using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(Order order);
        public Task<IEnumerable<Order>> GetAllOrdersAsync(string email);
        public Task<IEnumerable<Order>> GetUsersOrdersAsync();
        public Task<IEnumerable<DeliveryMethods>> GetDeliveryMethodsAsync();
    }
}
