using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class RefreshTokenRepo(AppDbContext _context) : Application.IRepository.IRefreshTokenRepo
    {
        public async Task Add(Domain.Models.RefreshToken token)
        {
             await _context.RefreshTokens.AddAsync(token);
        }

        public async Task Delete(Domain.Models.RefreshToken token)
        {
            var exist = await _context.RefreshTokens.FirstOrDefaultAsync(x=>x.Id==token.Id);
            if(exist != null )
            {
                exist.IsRevoked = true;
            }

            throw new NotFoundException("Refresh token not found");

        }

        public async Task<Domain.Models.RefreshToken?> GetByToken(string token)
        {
            return  await _context.RefreshTokens.FirstOrDefaultAsync(x=>x.Token==token);
        }
    }
}
