using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Repos.IRepos;

namespace moviedb_dotnet.Repos
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> _db;
        private readonly AppDBContext _dbc;

        public Repo(DbSet<TEntity> db, AppDBContext dbc)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _dbc = dbc ?? throw new ArgumentNullException(nameof(dbc));
        }

        public virtual async Task Create(TEntity obj)
        {
            await _db.AddAsync(obj);
            await CommitChanges();
        }

        public virtual async Task<TEntity?> FindOne(string id)
        {
            return await _db.Where(x => x.Id.ToString().Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            return await _db.ToListAsync();
        }

        public virtual async Task Delete(TEntity obj)
        {
            _db.Remove(obj);
            await CommitChanges();
        }

        public async Task CommitChanges()
        {
            await _dbc.SaveChangesAsync();
        }
    }
}
