using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            builder.Property(u => u.CheckIn)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.CheckOut)
                .IsRequired();

            builder.Property(u => u.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(r => r.CreatedAt)
                  .IsRequired()
                  .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(r => r.IsDeleted)
                  .IsRequired()
                  .HasDefaultValue(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(x=>x.Hotel)
                .WithMany(x=>x.Books)
                .HasForeignKey(x=>x.HotelId)
                .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
