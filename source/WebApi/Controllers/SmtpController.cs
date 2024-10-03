using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateUser;
using Project.Application.Features.Commands.SendEmail;
using Project.Application.Features.Commands.UpdateUser;
using Project.Application.Features.Queries.GetAllUsers;
using Project.Domain.Notifications;

namespace Project.WebApi.Controllers
{
    public class SmtpController : BaseController
    {
        private readonly IMediator _mediatorHandler;
        public SmtpController(INotificationHandler<DomainNotification> notifications,
                              INotificationHandler<DomainSuccesNotification> succesNotifications,
                              IMediator mediatorHandler) : base(notifications, succesNotifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost("test")]
        public async Task<IActionResult> EnvioEmailTeste([FromBody] SendEmailCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new SendEmailCommand(request)));
        }

    }
}
