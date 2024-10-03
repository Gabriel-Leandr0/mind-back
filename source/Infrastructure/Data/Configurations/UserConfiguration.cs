using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
        internal class UserConfiguration : IEntityTypeConfiguration<User>
        {
                public void Configure(EntityTypeBuilder<User> builder)
                {
                        builder.ToTable("T_USER");

                        builder.HasKey(x => x.Id);

                        builder.Property(x => x.Id)
                                .HasColumnName("PK_USER")
                                .ValueGeneratedOnAdd()
                                .IsRequired();

                        builder.Property(x => x.Login)
                                .HasColumnName("TX_LOGIN")
                                .IsRequired();

                        builder.Property(x => x.Password)
                                .HasColumnName("TX_PASSWORD")
                                .IsRequired();

                        builder.Property(x => x.TeamId)
                                .HasColumnName("FK_TEAM")
                                .IsRequired();

                        builder.HasOne(x => x.Team)
                                .WithMany(y => y.Members)
                                .HasForeignKey(x => x.TeamId)
                                .HasConstraintName("FK_TEAM");
                }
        }
}
