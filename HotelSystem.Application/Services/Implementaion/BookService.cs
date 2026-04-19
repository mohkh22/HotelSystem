using AutoMapper;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Request.Book;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Book;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Implementaion
{
    public class BookService(IUnitOfWork _uow, IMapper _mapper) : IBookService
    {
        public async Task CreateBookAsync(CreateBookRequest book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            await _uow.BookRepo.CreateBookAsync(bookEntity);
            await _uow.SaveChangesAsync();

        }

        public async Task DeleteBookAsync(Guid id)
        {
             var book = await _uow.BookRepo.GetBookByIdAsync(id);
            if (book == null || book.IsDeleted)
                throw new NotFoundException("Not Found"); 
            await _uow.BookRepo.DeleteBookAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task<PageResult<BookResponse>> GetAllBooksAsync(int page = 1, int pagesize = 10)
        {
            var books =  await _uow.BookRepo.GetAllBooksAsync(page, pagesize);
            var mappedBooks = _mapper.Map<List<BookResponse>>(books);

            return new PageResult<BookResponse>
            {
                Page = page,
                PageSize = pagesize,
                TotalCount = books.Count,
                Items = mappedBooks
            };
        }

        public async Task<BookResponse> GetBookByIdAsync(Guid id)
        {
            var book = await _uow.BookRepo.GetBookByIdAsync(id);
            if (book == null || book.IsDeleted)
                throw new NotFoundException("Not Found");
            var mappedBook = _mapper.Map<BookResponse>(book);
            return mappedBook;
        }

        public async Task UpdateBookAsync(UpdateBookRequest book)
        {
            var existBook = await _uow.BookRepo.GetBookByIdAsync(book.Id);
            if (existBook == null || existBook.IsDeleted)
                throw new NotFoundException("Not Found");

            _mapper.Map(book, existBook);
            await _uow.SaveChangesAsync();
        }
    }
}
