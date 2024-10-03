using Project.Domain.DTOs.Smtp.SendEmail;

namespace Project.Domain.Integrations.Interfaces;

public interface ISmtpService
{
    Task SendEmailAsync(SendEmailRequestDTO request);
}