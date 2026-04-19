using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IUserRoleRepo
    {
        Task Add(UserRole userRole);
        Task<List<string>> GetByUserId(Guid id);

    }
}
