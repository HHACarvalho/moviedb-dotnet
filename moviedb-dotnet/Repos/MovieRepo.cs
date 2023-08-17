using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Core;
using moviedb_dotnet.Domain;
using moviedb_dotnet.Repos.IRepos;

namespace moviedb_dotnet.Repos
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDBContext _db;

        public MovieRepo(AppDBContext dbContext)
        {
            _db = dbContext;
        }

        public async Task CreateMovie(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await CommitChanges();
        }

        public async Task<Movie?> FindOneMovie(string id)
        {
            return await _db.Movies.Where(x => x.Id.ToString().Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> FindMovies(string title)
        {
            return await _db.Movies.Where(x => x.Title.Contains(title)).ToListAsync();
        }

        public async Task<List<Movie>> FindAllMovies()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _db.Movies.Remove(movie);
            await CommitChanges();
        }

        public async Task CommitChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
