using Microsoft.AspNetCore.Mvc;
using moviedb_dotnet.Core;
using moviedb_dotnet.Core.Infrastructure;
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

        private async Task<IActionResult> HandleServiceCall<T>(Func<Task<Result<T>>> serviceCall, string methodName) where T : class
        {
            try
            {
                var result = await serviceCall();
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false, methodName));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(true, methodName));
                return Ok(result.Value);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode != null ? (int)ex.StatusCode : StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieRequestBody dto)
        {
            return await HandleServiceCall(async () => await _service.CreateMovie(Request.Cookies["token"], dto), "CreateMovie");
        }

        [HttpGet]
        public async Task<IActionResult> FindOneMovie([FromQuery(Name = "id")] string id)
        {
            return await HandleServiceCall(async () => await _service.FindOneMovie(id), "FindOneMovie");
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindMovies([FromQuery(Name = "title")] string title)
        {
            return await HandleServiceCall(async () => await _service.FindMovies(title), "FindMovies");
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllMovies([FromQuery(Name = "pageNumber")] int pageNumber, [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllMovies(pageNumber, pageSize), "FindAllMovies");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieRequestBody dto, [FromQuery(Name = "id")] string id)
        {
            return await HandleServiceCall(async () => await _service.UpdateMovie(Request.Cookies["token"], dto, id), "UpdateMovie");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromQuery(Name = "id")] string id)
        {
            return await HandleServiceCall(async () => await _service.DeleteMovie(Request.Cookies["token"], id), "DeleteMovie");
        }
    }
}
