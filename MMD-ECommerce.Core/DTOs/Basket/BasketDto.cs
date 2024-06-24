namespace MMD_ECommerce.Core.DTOs.Basket
{
    public class BasketDto
    {
        public string Id { get; set; }

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? ClientSecret { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
    }
}
