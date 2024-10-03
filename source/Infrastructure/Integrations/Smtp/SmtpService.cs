using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Project.Infrastructure.Integrations.Smtp;
using Project.Domain.Integrations.Interfaces;
using Project.Domain.DTOs.Smtp.SendEmail;
namespace Project.Infrastructure.Smtp;
public class SmtpService : ISmtpService
{

    private readonly SmtpOptions _SmtpOptions;

    public SmtpService(IOptions<SmtpOptions> SmtpOptions){
        _SmtpOptions = SmtpOptions.Value;
    }

    public async Task SendEmailAsync(SendEmailRequestDTO request)
    {
        var emailClient = new SmtpClient(_SmtpOptions.Server, _SmtpOptions.Port)
        {
            Credentials = new NetworkCredential(_SmtpOptions.Username, _SmtpOptions.Password),
            EnableSsl = _SmtpOptions.EnableSsl
        };
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_SmtpOptions.Username),
            Subject = request.Subject,
            Body = request.Body
        };
        mailMessage.To.Add(request.Email);
        await emailClient.SendMailAsync(mailMessage);
    }
}
