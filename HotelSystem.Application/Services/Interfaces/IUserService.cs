using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.User;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse?> FindById(Guid id);
        public Task<Guid> Add(CreateUserRequest user);
        public Task Update(Guid id ,UpdateUserRequest user);
        public Task Delete(Guid Id);
        public Task<List<UserResponse>> GetAll(int page = 1, int pageSize = 10);
    }
}
