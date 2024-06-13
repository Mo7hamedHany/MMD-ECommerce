using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Categories;

namespace MMD_ECommerce.Core.Features.Category.Query.Models
{
    public class GetCategoryByIdQuery : IRequest<Response<CategoryDto>>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
