using FluentValidation;

namespace Application.Features.Auth.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.emailOrUsername).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.password).NotEmpty().WithMessage("Password is required");
    }
}

