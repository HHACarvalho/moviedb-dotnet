using Microsoft.AspNetCore.Mvc;
using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.DTOs;
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

        private async Task<IActionResult> HandleServiceCall<T>(Func<Task<Result<T>>> serviceCall) where T : class
        {
            try
            {
                var result = await serviceCall();
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Error);
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieRequestBody dto)
        {
            return await HandleServiceCall(async () => await _service.CreateMovie(Request.Cookies["token"], dto));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllMovies([FromQuery(Name = "pageNumber")] int pageNumber, [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllMovies(pageNumber, pageSize));
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindMovies([FromQuery(Name = "movieTitle")] string movieTitle)
        {
            return await HandleServiceCall(async () => await _service.FindMovies(movieTitle));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneMovie([FromQuery(Name = "movieId")] string movieId)
        {
            return await HandleServiceCall(async () => await _service.FindOneMovie(movieId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieRequestBody dto, [FromQuery(Name = "movieId")] string movieId)
        {
            return await HandleServiceCall(async () => await _service.UpdateMovie(Request.Cookies["token"], movieId, dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromQuery(Name = "movieId")] string movieId)
        {
            return await HandleServiceCall(async () => await _service.DeleteMovie(Request.Cookies["token"], movieId));
        }
    }
}
