using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
             builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            builder.Property(u => u.Username)
                        .IsRequired()
                        .HasMaxLength(50);

            builder.Property(u => u.Email)
                        .IsRequired()
                        .HasMaxLength(100);

            builder.Property(u => u.Password)
                        .IsRequired()
                        .HasMaxLength(255);

                builder.Property(u => u.IsConfirmedEmail)
                        .IsRequired();

            builder.Property(u => u.CreatedAt)
                        .IsRequired()
                        .HasDefaultValueSql("GETUTCDATE()");

                builder.Property(u => u.IsDeleted)
                        .IsRequired()
                        .HasDefaultValue(false);

                builder.HasMany(u => u.UserRoles)
                        .WithOne(ur => ur.User)
                        .HasForeignKey(ur => ur.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
