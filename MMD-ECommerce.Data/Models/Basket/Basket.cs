using MMD_ECommerce.Data.Bases;

namespace MMD_ECommerce.Data.Models.Basket
{
    public class Basket : ITimeTrackEntity
    {
        public string Id { get; set; }

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? ClientSecret { get; set; }

        public string? PaymentMethodId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        }
}
