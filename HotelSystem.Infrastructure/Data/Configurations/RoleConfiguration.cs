using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Domain.Models.Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Role> builder)
        {
              builder.HasKey(r => r.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

            builder.Property(r => r.Name)
                    .IsRequired()
                    .HasConversion<string>()
                    .HasDefaultValue(Domain.Enums.Role.User)
                    .HasMaxLength(100);

                builder.Property(r => r.CreatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()");

                builder.Property(r => r.IsDeleted)
                    .IsRequired()
                    .HasDefaultValue(false);

                    builder.HasMany(r => r.UserRoles)
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
