

using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Categories;
using MMD_ECommerce.Core.Features.Category.Query.Models;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Category.Query.Handlers
{
    public class CategoryQueryHandler : ResponseHandler,
        IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>,
        IRequestHandler<GetCategoryByIdQuery, Response<CategoryDto>>

    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategories();

            var mappedCategories = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return mappedCategories;
        }

        public async Task<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryById(request.Id);

            if (category == null) return NotFound<CategoryDto>("Category Not Found");

            var mappedCategory = _mapper.Map<CategoryDto>(category);

            return Success(mappedCategory);
        }
    }
}
