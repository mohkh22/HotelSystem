using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IRoomTypeRepo
    {
            Task<List<RoomType>> GetAllAsync(int page = 1 , int pageSize=10);
            Task<RoomType> GetByIdAsync(Guid id);
            Task<RoomType?> GetByNameAsync(string Name);
            Task AddAsync(RoomType roomType);
            Task UpdateAsync(RoomType roomType);
            Task DeleteAsync(Guid id);
    }
}
