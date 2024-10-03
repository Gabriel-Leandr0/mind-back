using Project.Application.Common.Interfaces;
using Project.Domain.Integrations.Interfaces;
using Project.Domain.DTOs.Smtp.SendEmail;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.SendEmail
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, SendEmailCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly ISmtpService _smtpService;

        public SendEmailCommandHandler(IUnitOfWork unitOfWork,
                                        IMediator mediator,
                                        ISmtpService smtpService)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _smtpService = smtpService;
        }

        public async Task<SendEmailCommandResponse?> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            if (ValidateBusinessRules(request.SendEmailCommandRequest))
            {
                try {
                    var emailRequest = new SendEmailRequestDTO(request.SendEmailCommandRequest.Email, request.SendEmailCommandRequest.Subject, request.SendEmailCommandRequest.Body);
                    await _smtpService.SendEmailAsync(emailRequest);
                    await _mediator.Publish(new DomainSuccesNotification("SendEmail", "Email enviado com sucesso"), cancellationToken);
                    return new SendEmailCommandResponse();
                } catch {
                    await _mediator.Publish(new DomainNotification("SendEmail", "Falha ao enviar email"), cancellationToken);
                    return default;
                }
            }
            else
            {
                return default;
            }
        }

        private bool ValidateBusinessRules(SendEmailCommandRequest request)
        {
            bool isValid = true;
            return isValid;
        }
    }
}
