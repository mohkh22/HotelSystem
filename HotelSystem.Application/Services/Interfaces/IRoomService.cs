using HotelSystem.Application.Request.Room;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Room;
using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IRoomService
    {
        Task<PageResult<RoomResponse>> GetAllRoomsAsync(int page = 1, int pageSize = 10);
        Task<PageResult<RoomResponse>> GetAllRoomsAsync(Guid HotelId, int page = 1, int pageSize = 10);
        Task<RoomResponse> GetRoomByIdAsync(Guid id);
        Task<Guid> AddRoomAsync(RoomRequest room);
        Task<RoomResponse> UpdateRoomAsync(Guid id ,UpdateRoomRequest room);
        Task DeleteRoomAsync(Guid id);
        Task UpdateStatus(Guid id, CleaningStatus Cleanstatus, Availability availability);
    }
}
