using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllUsers
{
    public class GetAllUsersQuery : Command<IEnumerable<GetAllUsersQueryResponse>>
    {
        public GetAllUsersQuery()
        {
        }
    }
}
