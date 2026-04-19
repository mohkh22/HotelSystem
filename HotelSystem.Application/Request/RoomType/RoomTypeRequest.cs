namespace HotelSystem.Application.Request.RoomType
{
    public class RoomTypeRequest
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
