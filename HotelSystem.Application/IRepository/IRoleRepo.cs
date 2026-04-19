using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IRoleRepo
    {
        Task Add(Role role); 
        Task Delete(Role role);
        Task<Role?> GetRoleByName (string roleName);
        Task<List<Role>> GetAll();
    }
}
