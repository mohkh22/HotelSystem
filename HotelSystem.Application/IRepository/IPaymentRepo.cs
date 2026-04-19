using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IPaymentRepo
    {
         Task AddPaymentAsync(Payment payment);
         Task<Payment> GetPaymentByIdAsync(Guid id);
         Task<Payment> GetPaymentByBookIdAsync(Guid id);
         Task<List<Payment>> GetAllPaymentsAsync(int page=1, int pageSize=10);
         Task UpdateStatusAsync(Guid id , PaymentStatus status);
         Task DeletePaymentAsync(Guid id);
    }
}
