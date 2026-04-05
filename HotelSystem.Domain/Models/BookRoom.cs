namespace HotelSystem.Domain.Models
{
    public class BookRoom
    {
        public int Id { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public Guid RoomId { get; set; }
        public Room? Room {get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
