using MMD_ECommerce.Data.Models.Order.Order;
using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(Order order);
        public Task<IEnumerable<DeliveryMethods>> GetDeliveryMethodsAsync();
        Task<IEnumerable<Order>> GetOrdersForUser(string email);
        Task<IEnumerable<Order>> GetAllSystemOrders();
    }
}
