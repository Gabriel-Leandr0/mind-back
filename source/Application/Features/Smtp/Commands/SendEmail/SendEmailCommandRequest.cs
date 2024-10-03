using System.Collections;

namespace Project.Application.Features.Commands.SendEmail
{
    public record SendEmailCommandRequest
    {
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Body { get; set; }
    }
}
