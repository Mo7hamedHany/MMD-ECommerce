using MediatR;
using MMD_ECommerce.Core.DTOs;
using MMD_ECommerce.Core.DTOs.Base;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Core.Features.Products.Query.Models
{
    public class GetProductsQuery : PaginatorRequestDto, IRequest<PaginatedResultDto<ProductToReturnDto>>
    {

    }
}
