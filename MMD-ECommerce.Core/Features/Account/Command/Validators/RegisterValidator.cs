using FluentValidation;
using MMD_ECommerce.Core.Features.Account.Command.Models;

namespace MMD_ECommerce.Core.Features.Account.Command.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            ApplyValidations();
        }

        public void ApplyValidations()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.Password)
                     .NotEmpty().WithMessage("Password is required.")
                     .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                     .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                     .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                     .Matches(@"[0-9]").WithMessage("Password must contain at least one number.");

        }
    }
}
