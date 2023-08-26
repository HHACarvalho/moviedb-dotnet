using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Domain;
using moviedb_dotnet.Repos.IRepos;

namespace moviedb_dotnet.Repos
{
    public class MovieRepo : Repo<Movie>, IMovieRepo
    {
        public MovieRepo(DbSet<Movie> db, AppDBContext dbc) : base(db, dbc) { }

        public async Task<List<Movie>> Find(string title)
        {
            return await _db.Where(x => x.Title.Contains(title)).ToListAsync();
        }
    }
}
