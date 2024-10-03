using Project.Domain.Entities;

namespace Project.Application.Features.Queries.GetAllUsers
{
    public class GetAllUsersQueryResponse
    {
        public required long Id { get; set; }
        public required string Login { get; set; }
        public required Team Team { get; set; }
        public required UserDetail UserDetail { get; set; }
        public required List<UserStack> UserStack { get; set; }

    }
}
