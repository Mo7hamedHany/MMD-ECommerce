using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Data.Models.Order.Order;

namespace MMD_ECommerce.Core.Features.Orders.Query.Models
{
    public class GetDeliveryMethodsQuery : IRequest<Response<IEnumerable<DeliveryMethods>>>
    {
    }
}
