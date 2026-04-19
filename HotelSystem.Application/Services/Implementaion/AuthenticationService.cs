using AutoMapper;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.Token;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Services.Interfaces;

namespace HotelSystem.Infrastructure.Services.Implementaion
{
    public class AuthenticationService(IUnitOfWork unitOfWork,ITokenService tokenService,IMapper _mapper) : IAuthenticationService
    {
        public async Task<TokenResponse> Login(LoginRequest user)
        {
            var existingUser = await unitOfWork.UserRepo.FindByEmail(user.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, existingUser?.Password))
            {
                throw new UnauthorizedAccessException("Invalid Email or password");
            }


             var token = tokenService.GenerateAccessToken(existingUser!);
            var refreshToken = tokenService.GenerateRefreshToken();

            await unitOfWork.RefreshTokenRepo.Add(new RefreshToken
            {
                UserId = existingUser!.Id,
                Token = refreshToken,
                ExpireDate = DateTime.UtcNow.AddDays(7)
            });
            await unitOfWork.SaveChangesAsync(); 

            return new TokenResponse
            {
                AccessToken = token,
                RefreshToken = refreshToken
            };
              
            
          
        }

        public async Task<Guid> Register(RegisterRequest user)
        {
             var existingUser = await  unitOfWork.UserRepo.IsEmailExist(user.Email);
            if (existingUser)
                throw  new ConflictException("Email already exists");
            var map = _mapper.Map<User>(user);
            map.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var role = await unitOfWork.RoleRepo.GetRoleByName(HotelSystem.Domain.Enums.Role.User.ToString());
            if (role == null)
                throw new NotFoundException("Default role notFound");

            map.UserRoles.Add(new UserRole
            {
                UserId = map.Id,
                RoleId = role.Id
            });
            await unitOfWork.UserRepo.Add(map);  
            await unitOfWork.SaveChangesAsync();
            return map.Id; 
         }
    }
}
