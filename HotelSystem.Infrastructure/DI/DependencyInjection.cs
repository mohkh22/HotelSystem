using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Services.Implementaion;
using HotelSystem.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelSystem.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbContect")); 
            }); 

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

    }
}
