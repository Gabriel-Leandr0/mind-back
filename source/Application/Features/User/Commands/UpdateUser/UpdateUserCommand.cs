using Project.Application.Features.Commands.CreateUser;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommand : Command<UpdateUserCommandResponse?>
    {
        public UpdateUserCommandRequest UpdateUserCommandRequest { get; set; }
        
        public UpdateUserCommand(UpdateUserCommandRequest request)
        {
            UpdateUserCommandRequest = request;
        }
    }
}
