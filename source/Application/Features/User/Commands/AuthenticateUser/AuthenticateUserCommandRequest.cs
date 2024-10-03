using System.Collections;

namespace Project.Application.Features.Commands.AuthenticateUser
{
    public record AuthenticateUserCommandRequest
    {
        public required string Login { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
