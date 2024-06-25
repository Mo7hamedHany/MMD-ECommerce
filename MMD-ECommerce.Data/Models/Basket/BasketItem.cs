using System.ComponentModel.DataAnnotations;

namespace MMD_ECommerce.Data.Models.Basket
{
    public class BasketItem
    {
        [Key]
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