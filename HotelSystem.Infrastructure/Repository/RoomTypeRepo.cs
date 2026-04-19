using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class RoomTypeRepo(AppDbContext _context) : IRoomTypeRepo
    {
        public async Task AddAsync(RoomType roomType)
                      => await  _context.RoomTypes.AddAsync(roomType);

        public async Task DeleteAsync(Guid id)
        {
             var exist = await  _context.RoomTypes.FindAsync(id);
            if (exist is  null || exist.IsDeleted)
                throw new NotFoundException("RoomType not found Or Already Deleted");
            exist.IsDeleted = true;
        }

        public async Task<List<RoomType>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return await _context.RoomTypes
                .AsNoTracking()
                .OrderBy(rt => rt.CreatedAt)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<RoomType> GetByIdAsync(Guid id)
        {
            var exist =  await _context.RoomTypes.FindAsync(id);
            if (exist is null || exist.IsDeleted)
                throw new NotFoundException("RoomType not found Or Deleted");

            return exist;

        }

        public async Task<RoomType?> GetByNameAsync(string Name)
        {
            var exist = await  _context.RoomTypes.FirstOrDefaultAsync(rt => rt.Type == Name);
            if (exist is null || exist.IsDeleted)
                return null; 

            return exist;
        }

        public async Task UpdateAsync(RoomType roomType)
        {
            var exist = await _context.RoomTypes.FindAsync(roomType.Id);
            if (exist is null)
                throw new NotFoundException("RoomType not found Or Deleted");

            exist.Type = roomType.Type;
        }
    }
}
