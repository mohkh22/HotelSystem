using HotelSystem.Domain.Models;
using Microsoft.Extensions.Options;

namespace HotelSystem.Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken(); 
    }
}
