
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Seeds
{
    internal class StackSeed : IEntityTypeConfiguration<Stack>
    {

        public void Configure(EntityTypeBuilder<Stack> builder)
        {
            builder.HasData(
                new Stack
                (
                    id: -1,
                    stackName: "C#"
                ),
                new Stack
                (
                    id: -2,
                    stackName: "Java"
                ),
                new Stack
                (
                    id: -3,
                    stackName: "Python"
                ),
                new Stack
                (
                    id: -4,
                    stackName: "JavaScript"
                ),
                new Stack
                (
                    id: -5,
                    stackName: "Ruby"
                )
            );
        }
    }
}