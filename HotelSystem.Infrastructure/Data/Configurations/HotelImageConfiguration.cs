using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    internal class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
    {
        public void Configure(EntityTypeBuilder<HotelImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

                builder.HasOne(x => x.Hotel)
                .WithMany(h => h.HotelImages)
                .HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()"); 

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);


        }
    }
}
