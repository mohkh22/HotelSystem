using HotelSystem.Domain.Enums;

namespace HotelSystem.Application.Response.Room
{
    public class RoomResponse
    {
        public string Number { get; set; } = null!;
        public decimal Price { get; set; }
        public Availability IsAvailable { get; set; }
        public CleaningStatus IsCleaned { get; set; }
        public Guid RoomTypeId { get; set; }
        public string RoomType { get; set; } = null!;
        public Guid HotelId { get; set; }
        public string HotelName { get; set; } = null!;

    }
}
