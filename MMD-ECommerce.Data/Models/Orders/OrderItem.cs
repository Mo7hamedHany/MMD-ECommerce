using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Data.Models.Products;

namespace MMD_ECommerce.Data.Models.Orders
{
    public class OrderItem : ModelKey<Guid>
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int productID { get; set; }

        public virtual Product Product { get; set; }
    }
}