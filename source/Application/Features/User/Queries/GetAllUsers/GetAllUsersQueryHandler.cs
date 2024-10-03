
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Application.Features.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<GetAllUsersQueryResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            
            return Task.FromResult(
                users.Select(x => new GetAllUsersQueryResponse
                {
                    Id = x.Id,
                    Login = x.Login,
                    Team = x.Team,
                    UserDetail = x.UserDetail,
                    UserStack = x.UserStacks.ToList()
                }).AsEnumerable());
        }
    }
}
