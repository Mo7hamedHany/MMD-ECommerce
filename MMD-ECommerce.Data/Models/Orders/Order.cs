using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Data.Models.Order.Order;
using MMD_ECommerce.Data.Models.Order;
using MMD_ECommerce.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Data.Models.Orders
{
    public class Order : ModelKey<Guid>, ITimeTrackEntity
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

        public decimal Total() => SubTotal + DeliveryMethod.Price;
    }
}
