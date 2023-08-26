namespace moviedb_dotnet.Repos.IRepos
{
    public interface IRepo<TEntity>
    {
        Task Create(TEntity obj);
        Task<TEntity?> FindOne(string id);
        Task<List<TEntity>> FindAll();
        Task Delete(TEntity obj);
        Task CommitChanges();
    }
}
