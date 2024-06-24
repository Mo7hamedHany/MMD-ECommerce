using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Categories;

namespace MMD_ECommerce.Core.Features.Category.Command.Models
{
    public class AddCategoryCommand : CategoryToCreateDto, IRequest<Response<string>>
    {
    }
}
