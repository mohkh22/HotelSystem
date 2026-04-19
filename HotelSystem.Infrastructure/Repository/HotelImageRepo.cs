using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class HotelImageRepo(AppDbContext _context) : IHotelImageRepo
    {
        public async Task AddImage(HotelImage image)
        {
              await _context.HotelImages.AddAsync(image);
        }

        public async Task DeleteImage(int id)
        {
             var exist = await _context.HotelImages.FindAsync(id);
            if (exist is null || exist.IsDeleted)
            {
                throw new NotFoundException("Image not found or Already Deleted");
            }
            exist.IsDeleted = true;
        }

        public async Task<List<HotelImage>> GetAllImagesByHotelId(Guid hotelId, int page = 1, int pageSize = 10)
        {
            return await _context.HotelImages
                .AsNoTracking()
                .Where(x => x.HotelId == hotelId)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<HotelImage> GetImageById(int id)
        {
             return await _context.HotelImages
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted)
                ?? throw new NotFoundException("Image not found");
        }
    }
}
