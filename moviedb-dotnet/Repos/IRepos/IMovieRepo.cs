using moviedb_dotnet.Domain;

namespace moviedb_dotnet.Repos.IRepos
{
    public interface IMovieRepo
    {
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie?> FindOneMovie(string id);
        Task<List<Movie>> FindMovies(string title);
        Task<List<Movie>> FindAllMovies();
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(string id);
    }
}
