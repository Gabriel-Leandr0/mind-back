using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IEncryptService _encryptService;
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public AuthenticateUserCommandHandler(IUnitOfWork unitOfWork,
                                                IMediator mediator,
                                                IEncryptService encryptService,
                                                IJwtService jwtService,
                                                IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _encryptService = encryptService;
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public async Task<AuthenticateUserCommandResponse?> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetWithIncludes(x => x.Login == request.AuthenticateUserCommandRequest.Login, y => y.Team).FirstOrDefault();



            if (user is not null && _encryptService.EncryptPassword(request.AuthenticateUserCommandRequest.Password) == user.Password)
            {
                var response = new AuthenticateUserCommandResponse
                {
                    Login = user.Login,
                    TeamName = user.Team.TeamName,
                    Token = _jwtService.GenerateJWT(user.Login, user.Team.TeamName)                    
                };

                return response;
            }
            else
            {
                await _mediator.Publish(new DomainNotification("Error authenticating user", "Invalid credentials. Try again!"));
            }

            return null;
        }
    }
}
