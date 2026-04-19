namespace HotelSystem.Application.Request.Book
{
    public class CreateBookRequest
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Price { get; set; }

    }
}
