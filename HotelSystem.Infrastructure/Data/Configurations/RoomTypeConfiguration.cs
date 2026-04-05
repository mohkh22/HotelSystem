using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            builder.Property(u => u.Type)
                .IsRequired()
                .HasMaxLength(100);

             builder.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

             builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
