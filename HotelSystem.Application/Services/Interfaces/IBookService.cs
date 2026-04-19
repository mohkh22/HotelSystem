using HotelSystem.Application.Request.Book;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Book;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateBookAsync(CreateBookRequest book);
        Task UpdateBookAsync(UpdateBookRequest book);
        Task DeleteBookAsync(Guid id);
        Task<BookResponse> GetBookByIdAsync(Guid id);
        Task<PageResult<BookResponse>> GetAllBooksAsync(int page = 1, int pagesize = 10);
    }
}
