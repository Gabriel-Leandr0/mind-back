using System.Text.Json.Serialization;

namespace Project.Application.Features.Commands.CreateUser
{
    public record UpdateUserCommandRequest
    {
        [JsonIgnore]
        public required long Id { get; set; }
        public string? Login { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public long? TeamId { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public List<long>? StackId { get; set; } = [];
    }
}
