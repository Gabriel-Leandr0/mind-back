using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.AuthenticateUser;
using Project.Application.Features.Commands.CreateUser;
using Project.Application.Features.Commands.UpdateUser;
using Project.Application.Features.Queries.GetAllUsers;
using Project.Domain.Notifications;

namespace Project.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediatorHandler;
        public UserController(INotificationHandler<DomainNotification> notifications,
                              INotificationHandler<DomainSuccesNotification> succesNotifications,
                              IMediator mediatorHandler) : base(notifications, succesNotifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new CreateUserCommand(request)));
        }

        [Authorize]
        [HttpPut()]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new UpdateUserCommand(request)));
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {
            return Response(await _mediatorHandler.Send(new GetAllUsersQuery()));
        }
        
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new AuthenticateUserCommand(request)));
        }
    }
}
