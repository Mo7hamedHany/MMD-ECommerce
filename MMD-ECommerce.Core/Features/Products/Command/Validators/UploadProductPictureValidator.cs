using FluentValidation;
using MMD_ECommerce.Core.Features.Products.Command.Models;

namespace MMD_ECommerce.Core.Features.Products.Command.Validators
{
    public class UploadProductPictureValidator : AbstractValidator<UploadProductPictureCommand>
    {

        public UploadProductPictureValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("No file uploaded.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.File.Length)
                        .LessThanOrEqualTo(2 * 1024 * 1024)
                        .WithMessage("File size must be less than or equal to 2 MB.");

                    RuleFor(x => x.File.ContentType)
                        .Must(BeAValidFileType)
                        .WithMessage("Only image files are allowed.");
                });
        }

        private bool BeAValidFileType(string fileType)
        {
            return fileType == "image/jpeg" || fileType == "image/png" || fileType == "image/gif";
        }
    }
}
