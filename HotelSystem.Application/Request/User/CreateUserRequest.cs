namespace HotelSystem.Application.Request.User
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid HotelId { get; set; } 
        public List<string> Roles { get; set; } = new List<string>();
    }
}
