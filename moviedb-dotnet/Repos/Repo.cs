using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Repos.IRepos;

namespace moviedb_dotnet.Repos
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : Entity
    {
        private readonly AppDBContext _dbc;
        protected readonly DbSet<TEntity> _dbs;

        public Repo(AppDBContext dbc, DbSet<TEntity> dbs)
        {
            _dbc = dbc ?? throw new ArgumentNullException(nameof(dbc));
            _dbs = dbs ?? throw new ArgumentNullException(nameof(dbs));
        }

        public virtual async Task Create(TEntity obj)
        {
            await _dbs.AddAsync(obj);
            await CommitChanges();
        }

        public virtual async Task<TEntity?> FindOne(string id)
        {
            return await _dbs.Where(x => x.Id.ToString().Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            return await _dbs.ToListAsync();
        }

        public virtual async Task Delete(TEntity obj)
        {
            _dbs.Remove(obj);
            await CommitChanges();
        }

        public async Task CommitChanges()
        {
            await _dbc.SaveChangesAsync();
        }
    }
}
