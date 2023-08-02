using moviedb_dotnet.Core;
using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Services.IServices
{
    public interface IMovieService
    {
        Task<Result<MovieBodyDTO>> CreateMovie(MovieBodyDTO dto);
        Task<Result<MovieBodyDTO>> FindOneMovie(string id);
        //Task<Result<string>> FindMovies(string title);
        //Task<Result<string>> FindAllMovies();
        //Task<Result<string>> UpdateMovie(string id);
        //Task<Result<string>> DeleteMovie(string id);
    }
}
