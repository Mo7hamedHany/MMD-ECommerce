namespace MMD_ECommerce.Core.DTOs.Product
{
    public class ProductToCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PictureName { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
