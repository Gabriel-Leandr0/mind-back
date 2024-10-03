using Microsoft.AspNetCore.Mvc;
using Project.Domain.Common;
using Project.Domain.Notifications;

namespace Project.WebApi.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : Controller
{
    private readonly DomainNotificationHandler _notifications;
    private readonly DomainSuccesNotificationHandler _succesNotifications;
    private readonly IMediator _mediatorHandler;

    protected Guid ClienteId;

    protected BaseController(INotificationHandler<DomainNotification> notifications,
                             INotificationHandler<DomainSuccesNotification> succesNotifications,
                             IMediator mediatorHandler)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _succesNotifications = (DomainSuccesNotificationHandler)succesNotifications;
        _mediatorHandler = mediatorHandler;
    }

    protected bool OperacaoValida()
    {
        return !_notifications.TemNotificacao();
    }

    protected IEnumerable<string> ObterMensagensErro()
    {
        return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
    }
    protected IEnumerable<string> ObterMensagensDeSucesso()
    {
        return _succesNotifications.ObterNotificacoes().Select(c => c.Value).ToList();
    }

    protected void NotificarErro(string codigo, string mensagem)
    {
        _mediatorHandler.Publish(new DomainNotification(codigo, mensagem));
    }

    protected new IActionResult Response(object? result = null)
    {
        if (OperacaoValida())
            return Ok(ResponseBase<object?>.Success(result, ObterMensagensDeSucesso()));

        return BadRequest(ResponseBase<object>.Failure(ObterMensagensErro()));
    }
}
