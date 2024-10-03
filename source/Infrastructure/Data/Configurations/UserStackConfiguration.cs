using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
    internal class UserStackConfiguration : IEntityTypeConfiguration<UserStack>
    {
        public void Configure(EntityTypeBuilder<UserStack> builder)
        {
            builder.ToTable("T_USER_STACK");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .HasColumnName("PK_USER_STACK")
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                    .HasColumnName("FK_USER")
                    .IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany(y => y.UserStacks)
                    .HasForeignKey(x => x.UserId)
                    .HasConstraintName("FK_USER");

            builder.Property(x => x.StackId)
                    .HasColumnName("FK_STACK")
                    .IsRequired();

            builder.HasOne(x => x.Stack)
                    .WithMany(y => y.UserStacks)
                    .HasForeignKey(x => x.StackId)
                    .HasConstraintName("FK_STACK");     
        }
    }
}
