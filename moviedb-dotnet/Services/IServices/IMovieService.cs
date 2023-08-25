using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Services.IServices
{
    public interface IMovieService
    {
        Task<Result<MovieDTO>> CreateMovie(MovieRequestBody dto);
        Task<Result<MovieDTO>> FindOneMovie(string id);
        Task<Result<List<MovieDTO>>> FindMovies(string title);
        Task<Result<List<MovieDTO>>> FindAllMovies();
        Task<Result<MovieDTO>> UpdateMovie(MovieRequestBody dto, string id);
        Task<Result<MovieDTO>> DeleteMovie(string id);
    }
}
