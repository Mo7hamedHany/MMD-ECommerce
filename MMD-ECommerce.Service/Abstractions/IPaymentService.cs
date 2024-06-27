using MMD_ECommerce.Data.Models.Basket;
using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IPaymentService
    {
        Task<Basket> CreateOrUpdatePaymentIntentForExistingOrder(Basket basket);

        Task<Basket> CreateOrUpdatePaymentIntentForNewOrder(string? basketId);

        Task<Order> UpdatePaymentStatusFailed(string paymentIntentId);

        Task<Order> UpdatePaymentStatusSuceeded(string paymentIntentId);

        Task<string> AddPayment(string paymentIntentId);

        //Task<Order> ConfirmPaymentAsync(string clientSecret, string paymentIntentId, string paymentMethodId);
    }
}
