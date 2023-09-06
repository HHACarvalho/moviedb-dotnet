using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Domain;
using moviedb_dotnet.Repos.IRepos;

namespace moviedb_dotnet.Repos
{
    public class MovieRepo : Repo<Movie>, IMovieRepo
    {
        public MovieRepo(AppDBContext dbc) : base(dbc, dbc.Movies) { }

        public async Task<List<Movie>> Find(string title)
        {
            return await _dbs.Where(x => x.Title.Contains(title)).ToListAsync();
        }

        public async Task<List<Movie>> FindAll(int pageNumber, int pageSize)
        {
            return await _dbs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
