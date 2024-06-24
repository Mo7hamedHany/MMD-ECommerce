using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Infrastructure.Specifications.Orders
{
    public class OrderWithPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentIdSpecification(string paymentIntentId)
            : base(order => order.PaymentIntentId == paymentIntentId)
        {
            IncludeExpressions.Add(del => del.DeliveryMethod);
        }
    }
}
