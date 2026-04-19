namespace HotelSystem.Application.Response.Hotel
{
    public class HotelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LocationUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        public int Capacity { get; set; }
    }
}
