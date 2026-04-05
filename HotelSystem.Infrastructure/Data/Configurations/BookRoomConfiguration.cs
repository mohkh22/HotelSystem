using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class BookRoomConfiguration : IEntityTypeConfiguration<BookRoom>
    {
        public void Configure(EntityTypeBuilder<BookRoom> builder)
        {
           builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); 

            builder.HasOne(x=>x.Book)
                .WithMany(b=>b.BookRooms)
                .HasForeignKey(x=>x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Room)
                .WithMany(r => r.BookRooms)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.CreatedAt)
                  .IsRequired()
                  .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(r => r.IsDeleted)
                  .IsRequired()
                  .HasDefaultValue(false);
        }
    }
}
