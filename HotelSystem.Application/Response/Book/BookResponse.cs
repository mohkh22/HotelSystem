using HotelSystem.Domain.Enums;

namespace HotelSystem.Application.Response.Book
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Price { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
