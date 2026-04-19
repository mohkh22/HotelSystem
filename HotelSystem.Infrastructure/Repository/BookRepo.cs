using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class BookRepo(AppDbContext _context) : IBookRepo
    {
        public async Task CreateBookAsync(Book book)
        {
            await  _context.Books.AddAsync(book);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var existbook = await _context.Books.FindAsync(id);
            if (existbook != null)
            {
                 existbook.IsDeleted = true;
            }
            throw new NotFoundException("the id is not found"); 
        }

        public async Task<List<Book>> GetAllBooksAsync(int page = 1 , int pagesize =10)
        {
            return  await _context.Books
                .AsNoTracking()
                .OrderByDescending(x=>x.CreatedAt)
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .ToListAsync(); 
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var book = await  _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new NotFoundException("the id is not found");
            }
            return book;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existbook =  await  _context.Books.FindAsync(book.Id);
            if(existbook ==null || existbook.IsDeleted)
            {
                throw new NotFoundException("Id is not found Or Book Deleted");
            }
             existbook.UserId = book.UserId;
             existbook.HotelId = book.HotelId;
             existbook.CheckIn = book.CheckIn;
             existbook.CheckOut = book.CheckOut;
             existbook.Price = book.Price;
        }
    }
}
