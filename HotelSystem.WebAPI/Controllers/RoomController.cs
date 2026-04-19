using HotelSystem.Application.Request.Room;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Room;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.WebAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController(IRoomService _service) : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll(int page=1 ,  int pagesize=10)
        {
            var result = await _service.GetAllRoomsAsync(page,pagesize);
            return Ok(new ApiResponse<PageResult<RoomResponse>>
            {
                Message = "Success",
                Data = result
            }); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AddRoom([FromBody] RoomRequest room)
        {
            var result = await _service.AddRoomAsync(room);
            return Created("", new ApiResponse<string>
            {
                Message = "Add Room Success",
                Data = result.ToString()
            }); 
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]

        public async Task<IActionResult> GetRoomById(Guid id )
        {
            var result = await _service.GetRoomByIdAsync(id);
            return Ok(new ApiResponse<RoomResponse>
            {
                Message = "Success",
                Data = result
            }); 
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin,Manager")]

        public async Task<IActionResult> UpdateRoom(Guid id , UpdateRoomRequest room)
        {
            var result = await _service.UpdateRoomAsync(id, room);
            return Ok(new ApiResponse<RoomResponse>
            {
                Message = "Update Success",
                Data = result
            }); 
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteRoom (Guid id )
        {
            await _service.DeleteRoomAsync(id);
            return Ok(new ApiResponse<String>
            {
                Message="Room Deleted Success"
            });
        }
    
    
    }
}
