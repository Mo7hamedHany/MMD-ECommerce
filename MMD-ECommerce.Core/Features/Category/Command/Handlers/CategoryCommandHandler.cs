using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.Features.Category.Command.Models;
using MMD_ECommerce.Service.Abstractions;
using CommandCategory = MMD_ECommerce.Data.Models.Products.Category;

namespace MMD_ECommerce.Core.Features.Category.Command.Handlers
{
    public class CategoryCommandHandler : ResponseHandler
        , IRequestHandler<AddCategoryCommand, Response<string>>
        , IRequestHandler<EditCategoryCommand, Response<string>>
        , IRequestHandler<DeleteCategoryCommand, Response<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedCategory = _mapper.Map<CommandCategory>(request);

            var CategoryResult = await _categoryService.CreateCategory(mappedCategory);

            if (CategoryResult == "Bad Request") return BadRequest<string>("Bad Request");
            else if (CategoryResult == "Success") return Created("Created Successfully");

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryById(request.Id);
            if (category == null) return NotFound<string>("Category Not Found");

            var mappedCategory = _mapper.Map<CommandCategory>(request);

            var result = await _categoryService.EditCategory(mappedCategory);

            if (result == "Success") return Success(result);
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.DeleteCategory(request.Id);

            if (result == "Success") return Deleted<string>();
            else if (result == "Not Found") return NotFound<string>("Category is not found");
            else return BadRequest<string>();
        }
    }
}
