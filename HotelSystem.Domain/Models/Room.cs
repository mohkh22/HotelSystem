using HotelSystem.Domain.Enums;

namespace HotelSystem.Domain.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = null!;
        public decimal Price { get; set; }
        public Availability IsAvailable { get; set; }
        public CleaningStatus IsCleaned { get; set; }

        public Guid RoomTypeId { get; set; }
        public RoomType? RoomType { get; set; }
        public Guid HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<BookRoom> BookRooms { get; set; } = new List<BookRoom>();

    }
}
