using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class UserRoleRepo(AppDbContext _context) : IUserRoleRepo
    {
        public async Task Add(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }

        public async Task<List<string>> GetByUserId(Guid id)
        {
            return await _context.UserRoles
                .Where(x => x.UserId == id)
                .Include(x => x.Role).Select(x=>x.Role.Name).ToListAsync(); 
        }
    }
}
