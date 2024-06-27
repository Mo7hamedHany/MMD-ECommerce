using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications.Orders;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public OrderService(IBasketService basketService, IUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }

        public async Task<string> CreateOrderAsync(Order order)
        {
            if (order == null) return "OrderIsNull";

            var basket = await _basketService.GetBasketAsync(order.BasketId);
            if (basket == null) return "BasketNotFound";

            var orderItems = new List<OrderItem>();
            foreach (var item in basket.BasketItems)
            {
                var product = await _unitOfWork.Repository<Product, int>().GetAsync(item.ProductId);
                if (product == null) continue;


                var orderItem = new OrderItem
                {
                    Product = await _unitOfWork.Repository<Product, int>().GetAsync(item.ProductId),
                    Quantity = item.Quantity,
                    Price = product.Price,
                };

                orderItems.Add(orderItem);
            }
            if (!orderItems.Any()) return "BasketItemsNotFound";

            if (!order.DeliveryMethodId.HasValue) return "NoDeliveryMethodSelected";
            var delivery = await _unitOfWork.Repository<DeliveryMethods, int>().GetAsync(order.DeliveryMethodId.Value);
            if (delivery == null) return "InvalidDeliveryMethodId";

            var spec = new OrderWithPaymentIntentIdSpecification(basket.PaymentIntentId);
            var existingOrder = await _unitOfWork.Repository<Order, Guid>().GetWithSpecsAsync(spec);

            if (existingOrder is not null)
            {
                _unitOfWork.Repository<Order, Guid>().Delete(existingOrder);
                await _paymentService.CreateOrUpdatePaymentIntentForExistingOrder(basket);
            }
            else
            {
                await _paymentService.CreateOrUpdatePaymentIntentForNewOrder(basket.Id);
            }



            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            var createdOrder = new Order
            {
                BuyerEmail = order.BuyerEmail,
                ShippingAddress = order.ShippingAddress,
                DeliveryMethod = delivery,
                OrderItems = orderItems,
                SubTotal = subTotal,
                PaymentIntentId = basket.PaymentIntentId,
                BasketId = basket.Id,
            };

            await _unitOfWork.Repository<Order, Guid>().AddAsync(createdOrder);
            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(string email)
        {
            var spec = new OrderSpecifications(email);

            var orders = await _unitOfWork.Repository<Order, Guid>().GetAllWithSpecsAsync(spec);

            return orders;
        }

        public async Task<IEnumerable<DeliveryMethods>> GetDeliveryMethodsAsync()
    => await _unitOfWork.Repository<DeliveryMethods, int>().GetAllAsync();

        public async Task<IEnumerable<Order>> GetUsersOrdersAsync()
            => await _unitOfWork.Repository<Order, Guid>().GetAllAsync();
    }
}
