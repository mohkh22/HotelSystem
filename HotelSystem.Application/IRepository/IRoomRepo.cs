using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IRoomRepo
    {
            Task<List<Room>> GetAllRoomsAsync(int page=1 , int pageSize=10);
            Task<List<Room>> GetAllRoomsAsync(Guid HotelId ,int page=1 , int pageSize=10);
            Task<Room> GetRoomByIdAsync(Guid id);
            Task AddRoomAsync(Room room);
            Task UpdateRoomAsync(Room room);
            Task DeleteRoomAsync(Guid id);
           Task<int> GetCountOfRoomsByHotelIdAsync(Guid hotelId);
    }
}
