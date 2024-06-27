namespace MMD_ECommerce.Core.DTOs.Order
{
    public class OrderToCreateDto
    {
        public string BasketId { get; set; }

        public string BuyerEmail { get; set; }

        public int? DeliveryMethodId { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }
    }
}
