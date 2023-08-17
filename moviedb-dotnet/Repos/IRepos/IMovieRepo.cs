using moviedb_dotnet.Domain;

namespace moviedb_dotnet.Repos.IRepos
{
    public interface IMovieRepo
    {
        Task CreateMovie(Movie movie);
        Task<Movie?> FindOneMovie(string id);
        Task<List<Movie>> FindMovies(string title);
        Task<List<Movie>> FindAllMovies();
        Task DeleteMovie(Movie movie);
        Task CommitChanges();
    }
}
