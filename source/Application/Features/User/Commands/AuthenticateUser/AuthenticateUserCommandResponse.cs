using Project.Domain.DTOs.Jwt.GenerateJwt;

namespace Project.Application.Features.Commands.AuthenticateUser
{
    public record AuthenticateUserCommandResponse
    {
        public string Login { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public GenerateJwtResponseDTO? Token { get; set; }  = new();
    }
}
