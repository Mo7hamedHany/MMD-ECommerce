using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Order;

namespace MMD_ECommerce.Core.Features.Orders.Query.Models
{
    public class GetAllOrdersQuery : IRequest<Response<IEnumerable<OrderResultDto>>>
    {
    }
}
