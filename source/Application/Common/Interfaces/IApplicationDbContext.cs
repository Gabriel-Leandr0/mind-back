using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Stack> Stack { get; set;}
    public DbSet<UserStack> UserStack { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<UserDetail> UserDetail {get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
