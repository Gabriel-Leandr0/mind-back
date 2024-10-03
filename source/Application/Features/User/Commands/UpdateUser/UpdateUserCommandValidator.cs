namespace Project.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UpdateUserCommandRequest.Id)
                .GreaterThan(0)
                .WithMessage("The {PropertyName} field must be greater than 0.");
            
            RuleFor(x => x.UpdateUserCommandRequest.Login)
                .MaximumLength(50)
                .WithMessage("The {PropertyName} field must have a maximum of 50 characters.");

            RuleFor(x => x.UpdateUserCommandRequest.FullName)
                .MaximumLength(100)
                .WithMessage("The {PropertyName} field must have a maximum of 100 characters.");

            RuleFor(x => x.UpdateUserCommandRequest.BirthDate)
                .LessThan(DateTime.Now)
                .WithMessage("The {PropertyName} field must be less than the current date.");

            RuleFor(x => x.UpdateUserCommandRequest.Bio)
                .MaximumLength(500)
                .WithMessage("The {PropertyName} field must have a maximum of 500 characters");

            RuleFor(x => x.UpdateUserCommandRequest.Email)
                .EmailAddress()
                .WithMessage("The {PropertyName} field must be a valid email address");

            RuleFor(x => x.UpdateUserCommandRequest.TeamId)
                .LessThan(0)
                .WithMessage("The {PropertyName} field must be less than 0.");
        }
    }
}
