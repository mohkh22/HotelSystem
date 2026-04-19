using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IRefreshTokenRepo
    {
        Task Add(RefreshToken token);
        Task Delete(RefreshToken token);
        Task<RefreshToken?> GetByToken(string token);

    }
}
