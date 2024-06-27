using MediatR;
using MMD_ECommerce.Core.DTOs;
using MMD_ECommerce.Core.DTOs.Base;
using MMD_ECommerce.Core.DTOs.Product;

namespace MMD_ECommerce.Core.Features.Products.Query.Models
{
    public class GetProductsQuery : PaginatorRequestDto, IRequest<PaginatedResultDto<ProductToReturnDto>>
    {

    }
}
