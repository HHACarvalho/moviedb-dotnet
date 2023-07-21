using Microsoft.AspNetCore.Mvc;

namespace moviedb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        [HttpPost]
        public IActionResult CreateMovie()
        {
            return Ok("Created movie");
        }

        [HttpGet]
        public IActionResult FindOneMovie()
        {
            return Ok("Find one movie");
        }

        [HttpGet("search")]
        public IActionResult FindMovies()
        {
            return Ok("Find movies");
        }

        [HttpGet("all")]
        public IActionResult FindAllMovies()
        {
            return Ok("Find all movies");
        }

        [HttpPut]
        public IActionResult UpdateMovie()
        {
            return Ok("Update movie");
        }

        [HttpDelete]
        public IActionResult DeleteMovie()
        {
            return Ok("Delete movie");
        }
    }
}
