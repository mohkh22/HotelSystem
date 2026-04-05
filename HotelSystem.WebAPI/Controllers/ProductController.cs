using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {

        [EndpointSummary("the summary")]
        [EndpointName("GetAllProducts")]
        [EndpointDescription("this is description")]
        [ProducesResponseType(StatusCodes.Status100Continue)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status205ResetContent)]
        [HttpGet]
        [Authorize]
        public IActionResult GetAllProduct()
        {
            string[] product = { "pro1", "pro2", "pro3" }; 

            return Ok(product);

        }

        [EndpointSummary("the summary")]
        [EndpointName("CreateProduct")]
        [EndpointDescription("this is description")]
        [HttpPost]
        public IActionResult CreateProduct()
        {
            string[] product = { "pro1", "pro2", "pro3" };

            return NoContent();

        }
    }
}
