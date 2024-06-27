using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Data.Models.Payments
{
    public class Payment : ModelKey<Guid>
    {
        public string PaymentIntentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }

}
