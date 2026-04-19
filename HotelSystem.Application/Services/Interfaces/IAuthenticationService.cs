using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.Token;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<TokenResponse>  Login (LoginRequest user); 
        public Task<Guid> Register (RegisterRequest user); 

    }
}
