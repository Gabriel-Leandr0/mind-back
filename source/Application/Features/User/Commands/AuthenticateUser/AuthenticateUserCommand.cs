using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : Command<AuthenticateUserCommandResponse>
    {
        public AuthenticateUserCommandRequest AuthenticateUserCommandRequest { get; set; }
        public AuthenticateUserCommand(AuthenticateUserCommandRequest request)
        {
            AuthenticateUserCommandRequest = request;
        }
    }
}
