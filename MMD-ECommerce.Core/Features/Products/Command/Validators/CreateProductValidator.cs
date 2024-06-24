using FluentValidation;
using MMD_ECommerce.Core.Features.Products.Command.Models;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Products.Command.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductService _productService;

        public CreateProductValidator(IProductService productService)
        {
            _productService = productService;
            ApplyValidationRules();
            ApplyCustomValidations();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("BrandId must be greater than zero");

            RuleFor(x => x.TypeId)
                .GreaterThan(0).WithMessage("TypeId must be greater than zero");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than zero");

            RuleFor(x => x.MerchantEmail)
                .EmailAddress().WithMessage("MerchantEmail must be a valid email address")
                .When(x => !string.IsNullOrEmpty(x.MerchantEmail));
        }

        public void ApplyCustomValidations()
        {
            RuleFor(x => x.BrandId)
               .MustAsync(async (Key, CancellationToken) => await _productService.BrandExists(Key)).WithMessage("Brand not exists");

            RuleFor(x => x.TypeId)
   .MustAsync(async (Key, CancellationToken) => await _productService.TypeExists(Key)).WithMessage("Type not exists");

            RuleFor(x => x.CategoryId)
   .MustAsync(async (Key, CancellationToken) => await _productService.CategoryExists(Key)).WithMessage("category not exists");
        }
    }
}
