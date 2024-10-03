namespace Project.Domain.DTOs.Jwt.GenerateJwt
{
    public class GenerateJwtResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}