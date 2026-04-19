using HotelSystem.Application.Request.RoomType;
using HotelSystem.Application.Response;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.WebAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/RoomType")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class RoomTypeController(IRoomTypeService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int page=1, [FromQuery] int pageSize=10)
        {
            var result = await _service.GetAllAsync(page, pageSize);
            return Ok(new ApiResponse<PageResult<RoomTypeRequest>>
            {
                Message ="Success",
                Data = result
            });
        }
   
        [HttpPost]
        public async Task<IActionResult> AddRoomType([FromBody] RoomTypeRequest type)
        {
            var result = await _service.AddAsync(type);
            return Created("", new ApiResponse<string>
            {
                Message = "Type Added Success",
                Data = result.ToString()
            });
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoomType(Guid id , UpdateRoomTypeRequest type)
        {
            var result = await _service.UpdateAsync(id, type);
            return Ok(new ApiResponse<RoomTypeRequest>
            {
                Message = "Type Updated Success",
                Data = result
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(Guid id )
        {
            await _service.DeleteAsync(id);
            return Ok(new ApiResponse<String>
            {
                Message="Type Deleted Success"
            });
        }

    }
}
