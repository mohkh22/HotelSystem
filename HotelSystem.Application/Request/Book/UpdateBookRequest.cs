namespace HotelSystem.Application.Request.Book
{
    public class UpdateBookRequest
    {
        public Guid RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Price { get; set; }
    }
}
