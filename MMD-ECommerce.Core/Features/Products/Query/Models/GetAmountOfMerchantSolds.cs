using MediatR;
using MMD_ECommerce.Core.Bases;

namespace MMD_ECommerce.Core.Features.Products.Query.Models
{
    public class GetAmountOfMerchantSolds : IRequest<Response<string>>
    {
        public GetAmountOfMerchantSolds(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
