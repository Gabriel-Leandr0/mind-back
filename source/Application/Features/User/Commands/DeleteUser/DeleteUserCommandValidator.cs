namespace Project.Application.Features.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.DeleteUserCommandRequest.Id)
                .NotNull().NotEmpty()
                .WithMessage("The {PropertyName} field is required.");
        }
    }
}