using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Order;

namespace MMD_ECommerce.Core.Features.Orders.Command.Models
{
    public class CreateOrderCommand : OrderToCreateDto, IRequest<Response<string>>
    {

    }
}
