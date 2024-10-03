using Project.Application.Common.Interfaces;
using Project.Application.Features.Commands.UpdateUser;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserStackRepository _userStackRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork,
                                        IMediator mediator,
                                        IUserRepository userRepository,
                                        IUserDetailRepository userDetailRepository,
                                        IUserStackRepository userStackRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _userStackRepository = userStackRepository;
        }

        public async Task<UpdateUserCommandResponse?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetWithIncludes(
              x => x.Id == request.UpdateUserCommandRequest.Id,
              y => y.UserDetail,
              y => y.Team,
              y => y.UserStacks
          ).FirstOrDefault();
          
            if (await ValidateBusinessRules(user, request.UpdateUserCommandRequest) && user is not null)
            {

                ValidateAndUpdateFields(user, request.UpdateUserCommandRequest);

                user = _userRepository.Update(user);

                _unitOfWork.Commit();

                await _mediator.Publish(new DomainSuccesNotification("Updated user", "User updated successfully"), cancellationToken);
                

                var response = new UpdateUserCommandResponse
                {
                    Id = user.Id,
                    Login = user.Login,
                    TeamId = user.TeamId,
                    FullName = user.UserDetail.Fullname,
                    BirthDate = user.UserDetail.BirthDate,
                    Bio = user.UserDetail.Bio,
                    Email = user.UserDetail.Email,
                    StackId = user.UserStacks.Select(x => x.StackId).ToList()
                };

                return response;
            }
            else
            {
                return default;
            }
        }

        private async Task<bool> ValidateBusinessRules(User? user, UpdateUserCommandRequest request)
        {
            bool isValid = true;

            if (user is null)
            {
                await _mediator.Publish(new DomainNotification("Error updating user", "Attention! User not found."));
                isValid = false;
            }

            var emailExists = _userDetailRepository.Get(x => x.Email == request.Email && x.Id != request.Id);

            if (emailExists != null)
            {
                await _mediator.Publish(new DomainNotification("Error updating user", "Check that the fields are completed. The Email field is already registered!"));
                isValid = false;
            }

            return isValid;
        }

        private void ValidateAndUpdateFields(User user, UpdateUserCommandRequest request)
        {
            if (!string.IsNullOrEmpty(request.Login) && request.Login != user.Login)
            {
                user.UpdateLogin(request.Login);
            }

            if (request.TeamId != null && request.TeamId != 0 && request.TeamId != user.TeamId)
            {
                user.UpdateTeamId(request.TeamId.Value);
            }

            if (!string.IsNullOrEmpty(request.FullName) && request.FullName != user.UserDetail.Fullname)
            {
                user.UserDetail.UpdateFullname(request.FullName);
            }

            if (request.BirthDate != null && request.BirthDate != user.UserDetail.BirthDate)
            {
                user.UserDetail.UpdateBirthDate(request.BirthDate.Value);
            }

            if (!string.IsNullOrEmpty(request.Email) && request.Email != user.UserDetail.Email)
            {
                user.UserDetail.UpdateEmail(request.Email);
            }

            if (!string.IsNullOrEmpty(request.Bio) && request.Bio != user.UserDetail.Bio)
            {
                user.UserDetail.UpdateBio(request.Bio);
            }

            if (request.StackId != null && request.StackId.Count > 0)
            {
                var userStacks = _userStackRepository.GetWithIncludes(x => x.UserId == user.Id);

                foreach (var stack in userStacks)
                {
                    if (!request.StackId.Contains(stack.StackId))
                    {
                        _userStackRepository.Delete(stack);
                    }
                }

                foreach (var stackId in request.StackId)
                {
                    if (!userStacks.Any(x => x.StackId == stackId))
                    {
                        _userStackRepository.Add(new UserStack(user.Id, stackId));
                    }
                }
            }

        }
    }
}
