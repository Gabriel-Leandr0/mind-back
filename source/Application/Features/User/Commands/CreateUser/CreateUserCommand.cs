using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateUser
{
    public class CreateUserCommand : Command<CreateUserCommandResponse>
    {
        public CreateUserCommandRequest CreateUserCommandRequest { get; set; }
        public CreateUserCommand(CreateUserCommandRequest request)
        {
            CreateUserCommandRequest = request;
        }
    }
}
