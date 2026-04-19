using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.Token;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.WebAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService _service) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest user)
        {
            var result = await _service.Login(user);
            return Ok(new ApiResponse<TokenResponse>
            {
                Message= "Login successful",
                Data = result
            }); 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest user)
        {
            var result =  await _service.Register(user); 
            return Created(nameof(Login),new ApiResponse<string> {Message="User created", Data= result.ToString() });
        }

    }
}
