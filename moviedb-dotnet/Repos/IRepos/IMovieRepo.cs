using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Repos.IRepos
{
    public interface IMovieRepo
    {
        Task<bool> Exists(string id);
        Task<MovieBodyDTO> CreateMovie(MovieBodyDTO movie);
        Task<MovieBodyDTO> FindOneMovie(string id);
    }
}
