using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackingSerivce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        [HttpGet("ForDriver")]
        [Authorize(Roles = "Driver")]
        public IActionResult ForDriver()
        {
            return Ok("You are a driver");
        }

        [HttpGet("ForManager")]
        [Authorize(Roles = "Manager")]
        public IActionResult ForManager()
        {
            return Ok("You are a Manager");
        }
    }
}
