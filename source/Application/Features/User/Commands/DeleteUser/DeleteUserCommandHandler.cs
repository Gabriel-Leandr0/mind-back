using Project.Application.Common.Interfaces;
using Project.Application.Features.Commands.DeleteUser;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<DeleteUserCommandResponse?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get(x => x.Id == request.DeleteUserCommandRequest.Id);

            if (await ValidateBusinessRules(user) && user is not null)
            {
                _userRepository.Delete(user);

                _unitOfWork.Commit();

                await _mediator.Publish(new DomainSuccesNotification("User deleted", "User deleted successfully"), cancellationToken);

                return new DeleteUserCommandResponse { Id = user.Id };
            }
            else
            {
                return default;
            }
        }

        private async Task<bool> ValidateBusinessRules(User? user)
        {
            bool isValid = true;

            if (user is null)
            {
                await _mediator.Publish(new DomainNotification("Error deleting user", "Attention! User not found."));
                isValid = false;
            }

            return isValid;
        }
    }
}
