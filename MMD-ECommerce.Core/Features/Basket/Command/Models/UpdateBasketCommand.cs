using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Basket;

namespace MMD_ECommerce.Core.Features.Basket.Command.Models
{
    public class UpdateBasketCommand : BasketToCreateDto, IRequest<Response<string>>
    {
    }
}
