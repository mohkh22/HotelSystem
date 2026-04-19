using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }  // not add
        public DbSet<Hotel> Hotels { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; } // not add
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<BookRoom> BookRooms { get; set; }  // not add




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Hotel>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Room>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<RoomType>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<HotelImage>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Payment>().HasQueryFilter(b => !b.IsDeleted);

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
