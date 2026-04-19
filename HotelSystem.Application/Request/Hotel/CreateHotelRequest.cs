using Microsoft.AspNetCore.Http;

namespace HotelSystem.Application.Request.Hotel
{
    public class CreateHotelRequest
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LocationUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        public int Capacity { get; set; }
        public  List<IFormFile?> file { get; set; } = new List<IFormFile?>();
    }
}
