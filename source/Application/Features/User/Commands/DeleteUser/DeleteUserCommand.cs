using Project.Application.Features.Commands.CreateUser;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteUser
{
    public class DeleteUserCommand : Command<DeleteUserCommandResponse?>
    {

        public DeleteUserCommandRequest DeleteUserCommandRequest { get; set; }
        
        public DeleteUserCommand(DeleteUserCommandRequest request)
        {
            DeleteUserCommandRequest = request;
        }

    }
}
