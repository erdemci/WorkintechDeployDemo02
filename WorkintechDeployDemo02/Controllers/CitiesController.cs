using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkintechDeployDemo02.Models;

namespace WorkintechDeployDemo02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly WorkintechSqliteContext context;

        public CitiesController(WorkintechSqliteContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Cities);
        }

        [HttpPost]
        public IActionResult Post(string name)
        {
            var city = new City { Name = name };

            context.Cities.Add(city);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, string name)
        {
            var city = context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            city.Name = name;
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var city = context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            context.Cities.Remove(city);
            context.SaveChanges();
            return NoContent();
        }


    }
}
