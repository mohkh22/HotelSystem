using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Response.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
       public ICollection<RoleResponse> Roles { get; set; } = new List<RoleResponse>();

    }
}
