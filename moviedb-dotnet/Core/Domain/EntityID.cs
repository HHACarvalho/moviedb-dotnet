namespace moviedb_dotnet.Core.Domain
{
    public class EntityID
    {
        public string Value { get; }

        public EntityID(string? value)
        {
            Value = value ?? Guid.NewGuid().ToString();
        }
    }
}
