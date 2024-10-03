using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
