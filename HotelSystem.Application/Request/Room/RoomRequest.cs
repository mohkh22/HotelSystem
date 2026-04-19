namespace HotelSystem.Application.Request.Room
{
    public class RoomRequest
    {
        public string Number { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid HotelId { get; set; }
    }
}
