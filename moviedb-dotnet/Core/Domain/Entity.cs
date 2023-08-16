namespace moviedb_dotnet.Core.Domain
{
    public class Entity
    {
        public EntityID Id { get; }

        public Entity(EntityID? id)
        {
            Id = id ?? new EntityID(null);
        }
    }
}
