using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class RoleRepo(AppDbContext _context) : IRoleRepo
    {
        public async Task Add(Role role)
        {
            await _context.Roles.AddAsync(role); 
        }

        public async Task Delete(Role role)
        {
           var existRole = await _context.Roles.FindAsync(role.Id);
            if (existRole != null)
            {
                existRole.IsDeleted = true;
            }
            throw new NotFoundException("Role Already Deleted"); 
        }

        public async Task<List<Role>> GetAll()
        {
           return  await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleByName(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName); 
        }

    }
}
