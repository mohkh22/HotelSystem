using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();


            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(h => h.LocationUrl)
                .HasMaxLength(200);

            builder.Property(u=>u.Rating)
                .HasColumnType("decimal(2, 1)");  

            builder.Property(h => h.Capacity)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(r => r.IsDeleted)
                  .IsRequired()
                  .HasDefaultValue(false);

          
        }
    }
}
