namespace HotelSystem.Application.Request.Hotel
{
    public class UpdateHotelRequest
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LocationUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        public int Capacity { get; set; }
    }

}
