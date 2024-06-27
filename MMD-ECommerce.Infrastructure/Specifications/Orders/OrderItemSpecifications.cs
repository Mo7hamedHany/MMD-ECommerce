using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Infrastructure.Specifications.Orders
{
    public class OrderItemSpecifications : BaseSpecification<OrderItem>
    {
        public OrderItemSpecifications(int productId) :
            base(item => item.productID == productId)
        {
        }
    }
}
