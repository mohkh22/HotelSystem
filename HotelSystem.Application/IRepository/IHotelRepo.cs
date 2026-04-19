using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IHotelRepo
    {
        Task CreateHotelAsync(Hotel hotel);
        Task<bool> HotelIsExistAsync(string Name , string Address);
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<List<Hotel>> GetAllHotelsAsync(int page=1 , int pageSize =10);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(Guid id);
        Task<int> GetCapacityOFHotel(Guid hotelId);

    }
}
