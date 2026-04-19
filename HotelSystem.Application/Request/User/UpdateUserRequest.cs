namespace HotelSystem.Application.Request.User
{
    public class UpdateUserRequest
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        //public ICollection<string> UserRoles { get; set; } = new List<string>();

    }
}
