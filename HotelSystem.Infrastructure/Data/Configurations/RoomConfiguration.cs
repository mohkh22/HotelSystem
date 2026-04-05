using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            builder.Property(r => r.Number)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(r => r.Price)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");

            builder.Property(r => r.IsAvailable)
                  .IsRequired()
                  .HasConversion<string>()
                  .HasDefaultValue(Availability.Available)
                  .HasMaxLength(20);

            builder.Property(r => r.IsCleaned)
                    .IsRequired()
                    .HasConversion<string>()
                    .HasDefaultValue(CleaningStatus.Clean)
                    .HasMaxLength(20);

            builder.HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(r=>r.Hotel)
                .WithMany(h=>h.Rooms)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.CreatedAt)
                  .IsRequired()
                  .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(r => r.IsDeleted)
                  .IsRequired()
                  .HasDefaultValue(false);
        }
    }
}
