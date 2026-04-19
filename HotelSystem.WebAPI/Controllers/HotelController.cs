using HotelSystem.Application.Request.Hotel;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Hotel;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.WebAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/Hotel")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class HotelController(IHotelService _service, IHotelImageService _image) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllHotels(int page = 1, int pageSize = 10)
        {
            var Hotels = await _service.GetAllHotelsAsync();

            return Ok(new ApiResponse<PageResult<HotelResponse>>
            {
                Message = "Success",
                Data = Hotels
            });
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddHotel( [FromForm] CreateHotelRequest hotel)
        {
            var result = await _service.CreateHotelAsync(hotel);

            if (hotel.file != null && hotel.file.Count > 0)
            {
                await  _image.UploadImage(result, hotel.file!);
            }

            return Created("", new ApiResponse<String>
            {
                Message = "Created Success",
                Data = result.ToString()
            });
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHotelById(Guid Id)
        {
            var result = await _service.GetHotelByIdAsync(Id);

            return Ok(new ApiResponse<HotelResponse>
            {
                Message = "Success ",
                Data = result
            });
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHotel (Guid id , [FromBody] UpdateHotelRequest hotel)
        {
           var result =  await _service.UpdateHotelAsync(id, hotel);
            return Ok(new ApiResponse<string>
            {
                Message="Hotel Updated Successfully",
                Data = result.ToString()
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel (Guid id)
        {
           var result =  await _service.DeleteHotelAsync(id);
            return Ok(new ApiResponse<string>
            {
                Message = "Hotel Deleted Successfully",
                Data = result.ToString()
            });
        }

    }
}
