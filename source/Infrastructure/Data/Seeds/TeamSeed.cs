
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Seeds
{
    internal class TeamSeed : IEntityTypeConfiguration<Team>
    {

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team
                (
                    id: -1,
                    teamName: "Team Alpha"
                ),
                new Team
                (
                    id: -2,
                    teamName: "Team Beta"
                ),
                new Team
                (
                    id: -3,
                    teamName: "Team Gamma"
                ),
                new Team
                (
                    id: -4,
                    teamName: "Team Delta"
                ),
                new Team
                (
                    id: -5,
                    teamName: "Team Epsilon"
                )
            );
        }
    }
}