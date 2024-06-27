using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Order;
using System.Text.Json.Serialization;

namespace MMD_ECommerce.Core.Features.Orders.Query.Models
{
    public class GetOrdersForUserQuery : IRequest<Response<IEnumerable<OrderResultDto>>>
    {
        public GetOrdersForUserQuery(string? email)
        {
            Email = email;
        }

        [JsonIgnore]
        public string? Email { get; set; }

    }
}
