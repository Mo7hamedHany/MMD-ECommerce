using MediatR;

namespace MMD_ECommerce.Core.Features.Products.Query.Models
{
    public class GetAmountOfMerchantSolds : IRequest<string>
    {
        public GetAmountOfMerchantSolds(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
