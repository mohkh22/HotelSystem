using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class HotelRepo(AppDbContext _context) : IHotelRepo
    {
        public async Task CreateHotelAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
        }

        public async Task DeleteHotelAsync(Guid id)
        {
             var existhotel = await _context.Hotels.FindAsync(id);
            if(existhotel ==null || existhotel.IsDeleted)
                 throw new Exception("Hotel not found or Already Deleted");

            existhotel.IsDeleted = true;
        }

        public async Task<List<Hotel>> GetAllHotelsAsync(int page = 1, int pageSize = 10)
        {
             return await _context.Hotels
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCapacityOFHotel(Guid hotelId)
        {
            var existHotel = await _context.Hotels.FindAsync(hotelId);
            if (existHotel == null || existHotel.IsDeleted)
                throw new Exception("Hotel not found or  Deleted");

            return existHotel.Capacity;
        }

        public async Task<Hotel> GetHotelByIdAsync(Guid id)
        {
            var existhotel = await  _context.Hotels.FindAsync(id);
            if(existhotel == null || existhotel.IsDeleted)
                throw new Exception("Hotel not found or  Deleted");

            return existhotel;
        }

        public async Task<bool> HotelIsExistAsync(string Name, string Address)
        {
             var existhotel = await _context.Hotels.AnyAsync(x => x.Name == Name && x.Address == Address && !x.IsDeleted);
            return existhotel;
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            var existhotel = await  _context.Hotels.FindAsync(hotel.Id);
            if(existhotel == null || existhotel.IsDeleted)
                throw new Exception("Hotel not found or  Deleted");

            existhotel.Name = hotel.Name;
            existhotel.Address = hotel.Address;
            existhotel.LocationUrl = hotel.LocationUrl;
            existhotel.Rating = hotel.Rating;
            existhotel.Capacity = hotel.Capacity;

        }
    }
}
