namespace Project.Application.Features.Commands.CreateUser
{
    public record DeleteUserCommandRequest
    {
        public required long Id { get; set; }
    }
}
