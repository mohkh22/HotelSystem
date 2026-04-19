using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class PaymentRepo(AppDbContext _context) : IPaymentRepo
    {
        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment); 
        }

        public async Task DeletePaymentAsync(Guid id)
        {
            var exist = await _context.Payments.FindAsync(id);
            if (exist is null || exist.IsDeleted)
                throw new NotFoundException("Id Is not found Or Already Deleted");
            exist.IsDeleted = true;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync(int page = 1, int pageSize = 10)
        {
            return await _context.Payments
                .AsNoTracking()
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Payment> GetPaymentByBookIdAsync(Guid id)
        {
             var exxist = await _context.Payments.FirstOrDefaultAsync(x=>x.BookId == id);
            if (exxist is null || exxist.IsDeleted)
                throw new NotFoundException("BookId Is not found Or  Deleted");

            return exxist;

        }

        public async Task<Payment> GetPaymentByIdAsync(Guid id)
        {
            var exxist = await _context.Payments.FindAsync(id);
            if (exxist is null || exxist.IsDeleted)
                throw new NotFoundException("Id Is not found Or  Deleted");

            return exxist;
        }

        public async Task UpdateStatusAsync(Guid id, PaymentStatus status)
        {
            var exist = await  _context.Payments.FindAsync(id);
            if (exist is null || exist.IsDeleted)
                throw new NotFoundException("Id Is not found Or Already Deleted");
            exist.Status = status;
        }
    }
}
