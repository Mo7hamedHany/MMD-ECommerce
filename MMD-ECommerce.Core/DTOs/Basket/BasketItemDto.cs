namespace MMD_ECommerce.Core.DTOs.Basket
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }

        public string TypeName { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }
    }
}
