using HotelSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRoom> BookRooms { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
