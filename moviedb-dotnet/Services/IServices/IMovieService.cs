using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Services.IServices
{
    public interface IMovieService
    {
        Task<Result<MovieDTO>> CreateMovie(string? jwt, MovieRequestBody dto);
        Task<Result<List<MovieDTO>>> FindAllMovies(int pageNumber, int pageSize);
        Task<Result<List<MovieDTO>>> FindMovies(string movieTitle);
        Task<Result<MovieDTO>> FindOneMovie(string movieId);
        Task<Result<MovieDTO>> UpdateMovie(string? jwt, string movieId, MovieRequestBody dto);
        Task<Result<MovieDTO>> DeleteMovie(string? jwt, string movieId);
    }
}
