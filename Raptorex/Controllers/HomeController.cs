using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Raptorex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to Raptorex API!");
        }

        [HttpGet("greet")]
        public IActionResult Greet([FromQuery] string name)
        {
            return Ok($"Hello, {name}!");
        }

        [HttpGet("greet/{age}")]
        public IActionResult GreetWithAge([FromQuery] string name, [FromRoute] int age)
        {
            return Ok($"Hello, {name}! You are {age} years old.");
        }
    }
}
