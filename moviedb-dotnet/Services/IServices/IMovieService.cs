using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Services.IServices
{
    public interface IMovieService
    {
        Task<Result<MovieDTO>> CreateMovie(string? jwt, MovieRequestBody dto);
        Task<Result<MovieDTO>> FindOneMovie(string id);
        Task<Result<List<MovieDTO>>> FindMovies(string title);
        Task<Result<List<MovieDTO>>> FindAllMovies(int pageNumber, int pageSize);
        Task<Result<MovieDTO>> UpdateMovie(string? jwt, MovieRequestBody dto, string id);
        Task<Result<MovieDTO>> DeleteMovie(string? jwt, string id);
    }
}
