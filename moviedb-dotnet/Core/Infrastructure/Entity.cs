namespace moviedb_dotnet.Core.Infrastructure
{
    public class Entity
    {
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
