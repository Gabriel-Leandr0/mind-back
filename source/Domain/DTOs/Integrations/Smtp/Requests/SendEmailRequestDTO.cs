namespace Project.Domain.DTOs.Integrations.Smtp.Requests;

public class SendEmailRequestDTO
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public SendEmailRequestDTO(string email, string subject, string body)
    {
        Email = email;
        Subject = subject;
        Body = body;
    }
}