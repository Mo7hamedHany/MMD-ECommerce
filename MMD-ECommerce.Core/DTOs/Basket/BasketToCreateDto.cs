namespace MMD_ECommerce.Core.DTOs.Basket
{
    public class BasketToCreateDto
    {
        public string Id { get; set; }

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? ClientSecret { get; set; }

        public List<BasketItemToCreateDto> BasketItems { get; set; } = new List<BasketItemToCreateDto>();
    }
}
