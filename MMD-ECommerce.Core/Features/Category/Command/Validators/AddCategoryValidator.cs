using FluentValidation;
using MMD_ECommerce.Core.Features.Category.Command.Models;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Category.Command.Validators
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryValidator(ICategoryService categoryService)
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
                .MustAsync(async (Key, CancellationToken) => await _categoryService.IsCategoryExist(Key))
                .WithMessage("Name Already exists");
        }

    }
}
