using System.Collections;

namespace Project.Application.Features.Commands.CreateUser
{
    public record CreateUserCommandRequest
    {
        public required string Login { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required long TeamId { get; set; }
        public required string FullName { get; set; } = string.Empty;
        public required DateTime BirthDate { get; set; }
        public required string Email { get; set; } = string.Empty;
        public required string Bio { get; set; } = string.Empty;
        public required  List<long> StackId { get; set; } = [];
    }
}
