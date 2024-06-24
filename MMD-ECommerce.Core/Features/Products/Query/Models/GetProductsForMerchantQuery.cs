using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Product;

namespace MMD_ECommerce.Core.Features.Products.Query.Models
{
    public class GetProductsForMerchantQuery : IRequest<Response<IEnumerable<ProductToReturnDto>>>
    {
        public string Email { get; set; }

        public GetProductsForMerchantQuery(string email)
        {
            Email = email;
        }
    }
}
