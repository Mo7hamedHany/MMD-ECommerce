using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Product;

namespace MMD_ECommerce.Core.Features.Products.Command.Models
{
    public class EditProductCommand : ProductToEditDto, IRequest<Response<string>>
    {
    }
}
