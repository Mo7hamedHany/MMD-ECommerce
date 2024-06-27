using FluentValidation;
using MMD_ECommerce.Core.Features.Category.Command.Models;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Category.Command.Validators
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public EditCategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            ApplyValidationRules();
            ApplyCustomValidations();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be Empty")
                .NotNull().WithMessage("Name must not be null");
        }

        public void ApplyCustomValidations()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => await _categoryService.IsCategoryExistExcludeSelf(Key, model.Id))
                .WithMessage("Name Already exists");
        }

    }
}
