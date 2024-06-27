using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Infrastructure.Specifications.Orders
{
    public class OrderSpecifications : BaseSpecification<Order>
    {
        public OrderSpecifications(string email)
            : base(order => order.BuyerEmail == email)
        {
            IncludeExpressions.Add(order => order.DeliveryMethod);
            IncludeExpressions.Add(order => order.OrderItems);
            AddThenInclude(order => order.OrderItems, orderItem => ((OrderItem)orderItem).Product);

        }

        public OrderSpecifications(Guid id, string email)
    : base(order => order.BuyerEmail == email && order.Id == id)
        {
            IncludeExpressions.Add(order => order.DeliveryMethod);
            IncludeExpressions.Add(order => order.OrderItems);
            AddThenInclude(order => order.OrderItems, orderItem => ((OrderItem)orderItem).Product);

        }

        public OrderSpecifications(PaymentStatus status)
            : base(order => order.paymentStatus == status)
        {
            IncludeExpressions.Add(order => order.DeliveryMethod);
            IncludeExpressions.Add(order => order.OrderItems);
            AddThenInclude(order => order.OrderItems, orderItem => ((OrderItem)orderItem).Product);
        }


    }
}
