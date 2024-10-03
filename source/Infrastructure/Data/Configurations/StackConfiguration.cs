using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
    internal class StackConfiguration : IEntityTypeConfiguration<Stack>
    {
        public void Configure(EntityTypeBuilder<Stack> builder)
        {
            builder.ToTable("T_STACK");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .HasColumnName("PK_STACK")
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.StackName)
                    .HasColumnName("TX_STACK_NAME")
                    .IsRequired();
        }
    }
}
