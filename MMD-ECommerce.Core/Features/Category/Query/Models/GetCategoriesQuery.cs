using MediatR;
using MMD_ECommerce.Core.DTOs.Categories;

namespace MMD_ECommerce.Core.Features.Category.Query.Models
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
