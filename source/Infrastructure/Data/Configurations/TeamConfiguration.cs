using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("T_TEAM");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .HasColumnName("PK_TEAM")
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.TeamName)
                    .HasColumnName("TX_TEAM_NAME")
                    .IsRequired();
        }
    }
}
