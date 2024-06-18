using MediatR;
using MMD_ECommerce.Core.Bases;

namespace MMD_ECommerce.Core.Features.Account.Command.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
