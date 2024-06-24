using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Product;

namespace MMD_ECommerce.Core.Features.Products.Query.Models
{
    public class GetProductByIdQuery : IRequest<Response<ProductToReturnDto>>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
