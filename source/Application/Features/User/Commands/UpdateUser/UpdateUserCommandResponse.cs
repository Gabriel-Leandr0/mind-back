namespace Project.Application.Features.Commands.UpdateUser
{
    public record UpdateUserCommandResponse
    {
        public long? Id { get; set; }
        public string? Login { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string? Bio { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public long? TeamId { get; set; }
        public List<long>? StackId { get; set; } = new List<long>();
    }
}
