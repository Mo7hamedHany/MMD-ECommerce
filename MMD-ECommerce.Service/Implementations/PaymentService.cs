using Microsoft.Extensions.Configuration;
using MMD_ECommerce.Data.Models.Basket;
using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications.Orders;
using MMD_ECommerce.Service.Abstractions;
using Stripe;

namespace MMD_ECommerce.Service.Implementations
{
    public class PaymentService : IPaymentService
    {

        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public PaymentService(IBasketService basketService, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<Basket> CreateOrUpdatePaymentIntentForExistingOrder(Basket basket)
        {
            StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];

            var total = basket.BasketItems.Sum(x => x.Price + x.Quantity);

            if (!basket.DeliveryMethodId.HasValue) throw new Exception("no delivery Method found for this basket");
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethods, int>().GetAsync(basket.DeliveryMethodId.Value);
            var shippingPrice = deliveryMethod.Price;

            long amount = (long)(100 * (shippingPrice + total));

            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = amount,
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }
            await _basketService.UpdateBasketAsync(basket);

            return basket;

        }

        public async Task<Basket> CreateOrUpdatePaymentIntentForNewOrder(string? basketId)
        {
            StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];

            var basket = await _basketService.GetBasketAsync(basketId);

            var total = basket.BasketItems.Sum(x => x.Price + x.Quantity);

            if (!basket.DeliveryMethodId.HasValue) throw new Exception("no delivery Method found for this basket");
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethods, int>().GetAsync(basket.DeliveryMethodId.Value);
            var shippingPrice = deliveryMethod.Price;

            long amount = (long)(100 * (shippingPrice + total));

            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = amount,
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }
            await _basketService.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task<Order> UpdatePaymentStatusFailed(string paymentIntentId)
        {
            var spec = new OrderWithPaymentIntentIdSpecification(paymentIntentId);
            var order = await _unitOfWork.Repository<Order, Guid>().GetWithSpecsAsync(spec);

            order.paymentStatus = PaymentStatus.Failed;
            _unitOfWork.Repository<Order, Guid>().Update(order);

            await _unitOfWork.CompleteAsync();

            return order;
        }

        public async Task<Order> UpdatePaymentStatusSuceeded(string paymentIntentId)
        {
            var spec = new OrderWithPaymentIntentIdSpecification(paymentIntentId);
            var order = await _unitOfWork.Repository<Order, Guid>().GetWithSpecsAsync(spec);

            order.paymentStatus = PaymentStatus.Received;
            _unitOfWork.Repository<Order, Guid>().Update(order);

            await _unitOfWork.CompleteAsync();

            await _basketService.DeleteBasketAsync(order.BasketId);

            return order;
        }
    }
}
