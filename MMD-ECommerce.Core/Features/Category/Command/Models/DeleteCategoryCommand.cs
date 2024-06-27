using MediatR;
using MMD_ECommerce.Core.Bases;

namespace MMD_ECommerce.Core.Features.Category.Command.Models
{
    public class DeleteCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
