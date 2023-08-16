using moviedb_dotnet.Domain;
using moviedb_dotnet.Repos.IRepos;

namespace moviedb_dotnet.Repos
{
    public class MovieRepo : IMovieRepo
    {
        public async Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> FindAllMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> FindMovies(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie?> FindOneMovie(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
