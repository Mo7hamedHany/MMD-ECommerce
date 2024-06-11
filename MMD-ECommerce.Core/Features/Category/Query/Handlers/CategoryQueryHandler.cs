

using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.DTOs;
using MMD_ECommerce.Core.Features.Category.Query.Models;
using MMD_ECommerce.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Core.Features.Category.Query.Handlers
{
    public class CategoryQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly  ICategoryService _categoryService;
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
    }
}
