using HotelSystem.Application.Services.Implementaion;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Infrastructure.Services.Implementaion;
using Microsoft.Extensions.DependencyInjection;

namespace HotelSystem.Application
{
    public static class RegisterServiceInDI
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IHotelImageService, HotelImageService>();


            return services;
        }
    }
}
