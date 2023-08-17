using Microsoft.AspNetCore.Mvc;
using moviedb_dotnet.DTOs;
using moviedb_dotnet.Services.IServices;

namespace moviedb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _service;

        public MovieController(ILogger<MovieController> logger, IMovieService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync(MovieRequestBody dto)
        {
            try
            {
                var result = await _service.CreateMovie(dto);
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Error);
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult FindOneMovieAsync([FromQuery(Name = "id")] string id)
        {
            return Ok("Find one movie");
        }

        [HttpGet("search")]
        public IActionResult FindMovies([FromQuery(Name = "title")] string title)
        {
            return Ok("Find movies");
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllMovies()
        {
            try
            {
                var result = await _service.FindAllMovies();
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Error);
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromQuery(Name = "id")] string id)
        {
            return Ok("Update movie");
        }

        [HttpDelete]
        public IActionResult DeleteMovie([FromQuery(Name = "id")] string id)
        {
            return Ok("Delete movie");
        }
    }
}
