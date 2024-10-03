using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class UserStackRepository : RepositoryBase<UserStack>, IUserStackRepository
    {
        public UserStackRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
