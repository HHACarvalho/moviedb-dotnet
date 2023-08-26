using moviedb_dotnet.Domain;

namespace moviedb_dotnet.Repos.IRepos
{
    public interface IMovieRepo : IRepo<Movie>
    {
        Task<List<Movie>> Find(string title);
        Task<List<Movie>> FindAll(int pageNumber, int pageSize);
    }
}
