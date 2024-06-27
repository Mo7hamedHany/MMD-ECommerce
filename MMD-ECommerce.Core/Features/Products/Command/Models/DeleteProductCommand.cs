using MediatR;
using MMD_ECommerce.Core.Bases;

namespace MMD_ECommerce.Core.Features.Products.Command.Models
{
    public class DeleteProductCommand : IRequest<Response<string>>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
