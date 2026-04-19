using Microsoft.AspNetCore.Http;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IHotelImageService
    {
        Task UploadImage(Guid HotelId, List<IFormFile> file);
    }
}
