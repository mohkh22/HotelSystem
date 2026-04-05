namespace HotelSystem.Domain.Models
{
    public class HotelImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }= string.Empty;
        public Guid HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
