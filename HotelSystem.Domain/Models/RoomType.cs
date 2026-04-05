namespace HotelSystem.Domain.Models
{
    public class RoomType
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
