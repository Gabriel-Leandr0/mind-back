namespace Project.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {

        
            RuleFor(x => x.CreateUserCommandRequest.Login)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(x => x.CreateUserCommandRequest.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(x => x.CreateUserCommandRequest.TeamId)
                .NotEmpty().WithMessage("{PropertyName} is required.");
                
            RuleFor(x => x.CreateUserCommandRequest.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(x => x.CreateUserCommandRequest.Bio)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(x => x.CreateUserCommandRequest.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than today.");

        }
    }
}
