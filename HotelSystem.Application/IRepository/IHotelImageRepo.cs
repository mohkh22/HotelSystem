using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IHotelImageRepo
    {
        Task AddImage(HotelImage image); 
        Task DeleteImage(int id);
        Task<List<HotelImage>> GetAllImagesByHotelId(Guid hotelId, int page = 1, int pageSize = 10);
        Task<HotelImage> GetImageById(int id);

    }
}
