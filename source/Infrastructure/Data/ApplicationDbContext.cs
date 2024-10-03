using System.Reflection;
using Project.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
    }
    public DbSet<User> User { get; set; }
    public DbSet<Stack> Stack { get; set; }
    public DbSet<UserStack> UserStack { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<UserDetail> UserDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public int Commit()
    {
        return base.SaveChanges();
    }
}
