using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
             builder.HasKey(ur => ur.Id);
            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            builder.Property(u => u.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.IsDeleted)
                    .IsRequired()
                    .HasDefaultValue(false);
        }
    }
}
