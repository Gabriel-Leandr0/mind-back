namespace Project.Application.Features.Commands.CreateUser
{
    public record CreateUserCommandResponse
    {
        public required long Id { get; set; }
        public required string Login { get; set; } = string.Empty;
        public required string FullName { get; set; } = string.Empty;
        public required DateTime BirthDate { get; set; }
        public required string Bio { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required long TeamId { get; set; }
    }
}
