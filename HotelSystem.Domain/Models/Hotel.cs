namespace HotelSystem.Domain.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LocationUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
