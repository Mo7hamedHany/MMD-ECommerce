using MediatR;
using MMD_ECommerce.Core.Bases;

namespace MMD_ECommerce.Core.Features.Basket.Command.Models
{
    public class DeleteBasketCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }

        public DeleteBasketCommand(string id)
        {
            Id = id;
        }
    }
}
