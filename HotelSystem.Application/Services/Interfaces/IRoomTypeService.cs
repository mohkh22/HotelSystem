using HotelSystem.Application.Request.RoomType;
using HotelSystem.Application.Response;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<PageResult<RoomTypeRequest>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<RoomTypeRequest> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(RoomTypeRequest roomType);
        Task<RoomTypeRequest> UpdateAsync(Guid id , UpdateRoomTypeRequest roomType);
        Task DeleteAsync(Guid id);
    }
}
