using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.SendEmail
{
    public class SendEmailCommand : Command<SendEmailCommandResponse>
    {
        public SendEmailCommandRequest SendEmailCommandRequest { get; set; }
        public SendEmailCommand(SendEmailCommandRequest request)
        {
            SendEmailCommandRequest = request;
        }
    }
}
