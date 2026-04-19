using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.User;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Enums;
using HotelSystem.WebAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Manager")]
    public class UserController(IUserService _service) : ControllerBase
    {
        [HttpGet]   
        public async Task<IActionResult> GetUsers ([FromQuery] int page=1, [FromQuery] int pagesize = 10)
        {
            var result = await _service.GetAll(page,pagesize);
            return Ok(new ApiResponse<List<UserResponse>>
            {
                Message = "Success",
                Data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById (Guid id)
        {
            var result = await _service.FindById(id);
            if (result == null)
                return NotFound("User Not Found");

            return Ok(new ApiResponse<UserResponse>
            {
                Message = "Success",
                Data = result
            }); 
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserRequest user)
        {
            var result = await _service.Add(user);               
            return Created("", new ApiResponse<string>
            {
                Message = "User Created Success ",
                Data = result.ToString()
            });  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser (Guid id)
        {
            await _service.Delete(id);
            return Ok(new ApiResponse<string>
            {
                Message="User Deleted Success"
            });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody]  UpdateUserRequest user)
        {
            await _service.Update(id,user);
            return Ok(new ApiResponse<string>
            {
                Message = "User Updated Success"
            }); 
        }
    
    }
}
