namespace HotelSystem.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; } 
        public Guid HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public Payment?  Payment { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<BookRoom> BookRooms { get; set; }= new List<BookRoom>();
    }
}
