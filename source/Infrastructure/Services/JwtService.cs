using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Common.Interfaces;
using Project.Domain.DTOs.Jwt.GenerateJwt;
using Project.Domain.DTOs.Jwt.GetLoggedUser;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public JwtService(IConfiguration configuration,
                          IUserRepository userRepository,
                          IMapper mapper)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public GenerateJwtResponseDTO GenerateJWT(string user, string team)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"] ?? "");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new(ClaimTypes.Name, user),
                     new(ClaimTypes.Role, team)
                }),
                Expires = DateTime.Now.AddHours(Convert.ToInt32(_configuration["Jwt:ExpiryInHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return new GenerateJwtResponseDTO { Token = jwtSecurityTokenHandler.WriteToken(token) };
        }

        public string GetClaimJWT(string token, string claimType)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var securityToken = jwtSecurityTokenHandler.ReadJwtToken(token.Replace("Bearer ", "").Trim());

            var jwtSecurityToken = securityToken;

            var usuarioNameClaim = jwtSecurityToken?.Claims.FirstOrDefault(claim => claim.Type == claimType);

            if (usuarioNameClaim is not null)
            {
                return usuarioNameClaim.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public GetLoggedUserResponseDTO? GetLoggedUser(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new Exception("User not authenticated");

            string login = GetClaimJWT(token, "unique_name") ?? string.Empty;

            var user = _userRepository.GetWithIncludes(x => x.Login == login, y => y.Team).FirstOrDefault();

            if (user != null)
            {
                return new GetLoggedUserResponseDTO
                {
                    Id = user.Id,
                    Login = user.Login,
                    TeamId = user.TeamId
                };
            }
            else
            {
                return null;
            }
        }
    }
}