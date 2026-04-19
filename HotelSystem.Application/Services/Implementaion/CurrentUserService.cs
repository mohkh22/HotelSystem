using HotelSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HotelSystem.Application.Services.Implementaion
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserId { get; set; }

        public CurrentUserService(IHttpContextAccessor httpContext)
        {
            var user = httpContext.HttpContext?
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            UserId = Guid.Parse(user!); 
        }
    }
}
