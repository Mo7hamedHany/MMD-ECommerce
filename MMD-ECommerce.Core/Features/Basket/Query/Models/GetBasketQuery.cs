using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Basket;

namespace MMD_ECommerce.Core.Features.Basket.Query.Models
{
    public class GetBasketQuery : IRequest<Response<BasketDto>>
    {
        public string Id { get; set; }

        public GetBasketQuery(string id)
        {
            Id = id;
        }
    }
}
