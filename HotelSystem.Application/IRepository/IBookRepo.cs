using HotelSystem.Domain.Models;

namespace HotelSystem.Application.IRepository
{
    public interface IBookRepo
    {
            Task CreateBookAsync(Book book);
            Task UpdateBookAsync(Book book);
            Task DeleteBookAsync(Guid id);
            Task<Book> GetBookByIdAsync(Guid id);
            Task<List<Book>> GetAllBooksAsync(int page = 1, int pagesize = 10);
    }
}
