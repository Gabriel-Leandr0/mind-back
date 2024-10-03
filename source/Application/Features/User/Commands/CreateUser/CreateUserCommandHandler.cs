using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IEncryptService _encryptService;

        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserStackRepository _userStackRepository;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork,
                                        IMediator mediator,
                                        IEncryptService encryptService,
                                        IUserRepository userRepository,
                                        IUserDetailRepository userDetailRepository,
                                        IUserStackRepository userStackRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _encryptService = encryptService;
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _userStackRepository = userStackRepository;
        }

        public async Task<CreateUserCommandResponse?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await ValidateBusinessRules(request.CreateUserCommandRequest))
            {

                var user = new User(
                    login: request.CreateUserCommandRequest.Login,
                    password: _encryptService.EncryptPassword(request.CreateUserCommandRequest.Password),
                    teamId: request.CreateUserCommandRequest.TeamId
                );

                _userRepository.Add(user);

                _unitOfWork.Commit();

                var userDetail = new UserDetail(
                    fullname: request.CreateUserCommandRequest.FullName,
                    birthDate: request.CreateUserCommandRequest.BirthDate,
                    email: request.CreateUserCommandRequest.Email,
                    bio: request.CreateUserCommandRequest.Bio,
                    userId: user.Id
                );

                _userDetailRepository.Add(userDetail);


                foreach (var stackId in request.CreateUserCommandRequest.StackId)
                {
                    var userStack = new UserStack(
                        userId: user.Id,
                        stackId: stackId);

                    _userStackRepository.Add(userStack);
                }

                _unitOfWork.Commit();

                await _mediator.Publish(new DomainSuccesNotification("User created", "User registered successfully"), cancellationToken);

                var response = new CreateUserCommandResponse
                {
                    Id = user.Id,
                    Login = user.Login,
                    FullName = userDetail.Fullname,
                    BirthDate = userDetail.BirthDate,
                    Bio = userDetail.Bio,
                    Email = userDetail.Email,
                    TeamId = user.TeamId
                };

                return response;
            }
            else
            {
                return default;
            }
        }

        private async Task<bool> ValidateBusinessRules(CreateUserCommandRequest request)
        {
            bool isValid = true;

            var emailExists = _userDetailRepository.Get(x => x.Email == request.Email);

            if (emailExists != null)
            {
                await _mediator.Publish(new DomainNotification("Error creating user", "Check the fields are filled in. The Email field is already registered!"));
                isValid = false;
            }

            return isValid;
        }
    }
}
