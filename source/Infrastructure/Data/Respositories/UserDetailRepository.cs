using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class UserDetailRepository : RepositoryBase<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
