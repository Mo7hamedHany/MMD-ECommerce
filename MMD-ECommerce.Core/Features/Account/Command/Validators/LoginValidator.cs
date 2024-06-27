using FluentValidation;
using MMD_ECommerce.Core.Features.Account.Command.Models;

namespace MMD_ECommerce.Core.Features.Account.Command.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {

        public LoginValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }


        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email Can't be Empty")
                 .NotNull().WithMessage("Email Can't have a null value");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password Can't be empty")
                .NotNull().WithMessage("Password Can't be null");
        }

        public void ApplyCustomValidationsRules()
        {
        }
    }
}
