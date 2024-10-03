namespace Project.Application.Features.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(x => x.AuthenticateUserCommandRequest.Login)
                .NotEmpty().WithMessage("Login is required")
                .MaximumLength(50).WithMessage("Login must not exceed 50 characters");

            RuleFor(x => x.AuthenticateUserCommandRequest.Password)
                .NotEmpty().WithMessage("Password is required")
                .MaximumLength(50).WithMessage("Password must not exceed 50 characters");
        }
    }
}
