using Microsoft.AspNetCore.Mvc;
using moviedb_dotnet.Core;
using moviedb_dotnet.DTOs;
using moviedb_dotnet.Services.IServices;
using System.Diagnostics;

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
        public async Task<IActionResult> CreateMovie(MovieRequestBody dto)
        {
            try
            {
                var result = await _service.CreateMovie(dto);
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(false));
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindOneMovie([FromQuery(Name = "id")] string id)
        {
            try
            {
                var result = await _service.FindOneMovie(id);
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(false));
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindMovies([FromQuery(Name = "title")] string title)
        {
            try
            {
                var result = await _service.FindMovies(title);
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(false));
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllMovies()
        {
            try
            {
                var result = await _service.FindAllMovies();
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(false));
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieRequestBody dto, [FromQuery(Name = "id")] string id)
        {
            try
            {
                var result = await _service.UpdateMovie(dto, id);
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(false));
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromQuery(Name = "id")] string id)
        {
            try
            {
                var result = await _service.DeleteMovie(id);
                if (!result.IsSuccess)
                {
                    _logger.LogWarning(Utils.LogMessage(false));
                    return BadRequest(result.Error);
                }

                _logger.LogInformation(Utils.LogMessage(false));
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
