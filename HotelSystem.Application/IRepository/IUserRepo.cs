using HotelSystem.Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace HotelSystem.Application.IRepository
{
    public interface IUserRepo
    {
        public Task<bool> IsEmailExist(string email);
        public Task<User?> FindById(Guid id);
        public Task<User?> FindByEmail(string email);
        public Task Add(User user);
        public Task Update(User user);
        public void Delete(User user);
        public Task<List<User>> GetAll(Guid? HotelId=null ,  int page = 1, int pageSize = 10);


    }
}
