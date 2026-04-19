using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class UserRepo(AppDbContext _context) : IUserRepo
    {
        public async Task Add(User user) => await _context.Users.AddAsync(user);

        public void Delete(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found or Already Deleted");
            }
             existingUser.IsDeleted=true;
        }
        public async Task<User?> FindByEmail(string email) 
            => await _context.Users.Include(x=>x.UserRoles).ThenInclude(x=>x.Role).FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> FindById(Guid id)=> 
            await _context.Users.Include(x=>x.UserRoles)
            .ThenInclude(x=>x.Role).FirstOrDefaultAsync(x=>x.Id == id );

        public async Task<List<User>> GetAll(Guid? HotelId , int page = 1, int pageSize = 10)
        {
            var query =  _context.Users
                         .Include(x => x.UserRoles)
                         .ThenInclude(x => x.Role)
                         .AsNoTracking()
                         .AsQueryable();

            if (HotelId.HasValue)
            {
                query = query.Where(x => x.HotelId == HotelId.Value);
            }

            return await query
                .OrderByDescending(u => u.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        }

        public async Task<bool> IsEmailExist(string email)
                                        => await _context.Users.AnyAsync(u => u.Email == email);

        public async Task Update(User user)
        {
            var existingUser = await  _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;                        
        }
    }
}
