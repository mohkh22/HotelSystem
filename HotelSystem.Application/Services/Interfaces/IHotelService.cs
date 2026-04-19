using HotelSystem.Application.Request.Hotel;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Hotel;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IHotelService
    {
        Task<Guid> CreateHotelAsync(CreateHotelRequest hotel);
        Task<HotelResponse> GetHotelByIdAsync(Guid id);
        Task<PageResult<HotelResponse>> GetAllHotelsAsync(int page = 1, int pageSize = 10);
        Task<Guid> UpdateHotelAsync(Guid id, UpdateHotelRequest hotel);
        Task<Guid> DeleteHotelAsync(Guid id);
    }
}
