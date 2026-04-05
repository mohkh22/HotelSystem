namespace HotelSystem.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!; 
        public string Password { get; set; } = null!;
        public bool IsConfirmedEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation property for the many-to-many relationship with Role through UserRole
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Book> Books { get; set; } = new List<Book>();


    }
}
