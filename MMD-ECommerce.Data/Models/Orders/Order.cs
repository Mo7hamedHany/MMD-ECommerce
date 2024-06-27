using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Data.Models.Payments;

namespace MMD_ECommerce.Data.Models.Orders
{
    public class Order : ModelKey<Guid>, IBase
    {
        public string BuyerEmail { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ShippingAddress ShippingAddress { get; set; }

        public DeliveryMethods DeliveryMethod { get; set; }

        public int? DeliveryMethodId { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }

        public PaymentStatus paymentStatus { get; set; } = PaymentStatus.Pending;

        public decimal SubTotal { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? BasketId { get; set; }

        public Payment Payment { get; set; }

        public decimal Total() => SubTotal + DeliveryMethod.Price;
    }
}
