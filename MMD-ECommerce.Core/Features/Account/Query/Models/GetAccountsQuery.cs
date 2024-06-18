using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Account;

namespace MMD_ECommerce.Core.Features.Account.Query.Models
{
    public class GetAccountsQuery : IRequest<Response<IEnumerable<UserDto>>>
    {
        public string Role { get; set; }

        public GetAccountsQuery(string role)
        {
            Role = role;
        }
    }
}
