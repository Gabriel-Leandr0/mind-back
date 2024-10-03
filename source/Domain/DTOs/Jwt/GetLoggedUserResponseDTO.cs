namespace Project.Domain.DTOs.Jwt
{
    public class GetLoggedUserResponseDTO
    {
        public long Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public long TeamId { get; set; }
        
    }
}