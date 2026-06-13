using Microsoft.AspNetCore.Mvc;
using Raptorex.Models;

namespace Raptorex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase 
    {
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = new Person
            {
                Id = id,
                Name = "Yash Bansod",
                Email = "yash.bansod@example.com",
                Age = 23
            };
             
            return Ok(person);

        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }
    }
}
