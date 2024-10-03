using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
        internal class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
        {
                public void Configure(EntityTypeBuilder<UserDetail> builder)
                {
                        builder.ToTable("T_USER_DETAIL");

                        builder.HasKey(x => x.Id);

                        builder.Property(x => x.Id)
                                .HasColumnName("PK_USER_DETAIL")
                                .ValueGeneratedOnAdd();

                        builder.Property(x => x.Fullname)
                                .HasColumnName("TX_FULLNAME")
                                .IsRequired();

                        builder.Property(x => x.BirthDate)
                                .HasColumnName("DT_BIRTH_DATE")
                                .IsRequired();

                        builder.Property(x => x.Email)
                                .HasColumnName("TX_EMAIL")
                                .IsRequired();

                        builder.Property(x => x.Bio)
                                .HasColumnName("TX_BIO")
                                .IsRequired();

                        builder.Property(x => x.UserId)
                               .HasColumnName("FK_USER")
                               .IsRequired();

                        builder.HasOne(x => x.User)
                               .WithOne(y => y.UserDetail)
                               .HasForeignKey<UserDetail>(x => x.UserId)
                               .HasConstraintName("FK_USER");
                }
        }
}
