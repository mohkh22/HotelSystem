using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSystem.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
           builder.HasKey(p => p.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.TransactionId)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Method)
                .HasConversion<string>()
                .HasDefaultValue(PaymentMethod.CreditCard)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasDefaultValue(PaymentStatus.Pending)
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(p => p.IsDeleted)
             .HasDefaultValue(false);

                builder.HasOne(p => p.Book)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
