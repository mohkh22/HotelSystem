using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace HotelSystem.Application.Services.Implementaion
{
    public class HotelImageService(IUnitOfWork _uow) : IHotelImageService
    {
        public async Task UploadImage(Guid HotelId, List<IFormFile> file)
        {
            if (file != null && file.Count > 0)
            {
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image");

                if (!File.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
               foreach(var f in file)
                {

                    var fileName = Guid.NewGuid() + Path.GetExtension(f.FileName);
                    var filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = File.OpenWrite(filePath))
                    {
                        await f.CopyToAsync(stream);
                    }

                    await _uow.HotelImageRepo.AddImage(new HotelImage
                    {
                        HotelId = HotelId,
                        ImageUrl = filePath
                    });
                }
                await _uow.SaveChangesAsync();

            }

        }
    }
}
