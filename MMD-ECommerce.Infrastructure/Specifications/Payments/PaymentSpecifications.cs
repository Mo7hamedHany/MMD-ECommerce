using MMD_ECommerce.Data.Models.Payments;

namespace MMD_ECommerce.Infrastructure.Specifications.Payments
{
    public class PaymentSpecifications : BaseSpecification<Payment>
    {
        public PaymentSpecifications(string paymentIntentId)
            : base(payment => payment.PaymentIntentId == paymentIntentId)
        {
            IncludeExpressions.Add(x => x.Order);
        }
    }
}
