using Project.Domain.DTOs.Jwt.GenerateJwt;
using Project.Domain.DTOs.Jwt.GetLoggedUser;

namespace Project.Application.Common.Interfaces
{
    public interface IJwtService
    {
        GenerateJwtResponseDTO GenerateJWT(string usuario, string perfil);
        string GetClaimJWT(string token, string claimType);
        GetLoggedUserResponseDTO? GetLoggedUser(string token);
        //Task<string> GetRefreshJWT(Funcionario funcionario, CancellationToken cancellationToken);
    }
}