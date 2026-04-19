using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
             builder.HasKey(rt => rt.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(rt => rt.ExpireDate)
                .IsRequired();

            builder.Property(rt => rt.IsRevoked)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(rt => rt.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(rt => rt.UserId); 
        }
    }
}
