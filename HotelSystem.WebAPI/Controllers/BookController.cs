using HotelSystem.Application.Request.Book;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Book;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.WebAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    [Authorize]
    public class BookController(IBookService _service) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles ="Admin,Manager")]
        public async Task<IActionResult> GetAllBook(int page=1, int pageSize=10)
        {
            var result = await _service.GetAllBooksAsync(page, pageSize);
            return Ok(new ApiResponse<PageResult<BookResponse>>
            {
                Message = "Success",
                Data = result
            });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetBookById(Guid id )
        {
            var result = await _service.GetBookByIdAsync(id);
            return Ok(new ApiResponse<BookResponse>
            {
                Message = "Success",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest book)
        {
            await _service.CreateBookAsync(book);
            return Ok(new ApiResponse<string>
            {
                Message = "Book Created Success"
            });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CreateBook(Guid id , [FromBody] UpdateBookRequest book)
        {
            await _service.UpdateBookAsync(id, book);
            return Ok(new ApiResponse<string>
            {
                Message = "Book Updated Success"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id )
        {
            await _service.DeleteBookAsync(id);
            return Ok(new ApiResponse<string>
            {
                Message = "Book Deleted Success"
            });
        }

    }
}
