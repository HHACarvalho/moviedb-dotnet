using Microsoft.AspNetCore.Mvc;
using moviedb_dotnet.Services.IServices;

namespace moviedb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateMovie()
        {
            var result = _service.CreateMovie();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult FindOneMovie()
        {
            var result = _service.FindOneMovie("ID STRING");
            return Ok(result);
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
