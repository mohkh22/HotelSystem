using HotelSystem.Domain.Enums;

namespace HotelSystem.Domain.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public decimal Price { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
