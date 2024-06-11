using MMD_ECommerce.Data.Bases;

namespace MMD_ECommerce.Data.Models.Order
{
    public class OrderItem : ModelKey<Guid>
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public OrderItemProduct orderItemProduct { get; set; }
    }
}