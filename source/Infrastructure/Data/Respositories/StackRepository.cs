using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class StackRepository : RepositoryBase<Stack>, IStackRepository
    {
        public StackRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
