namespace moviedb_dotnet.DTOs
{
    public class MovieDTO
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Director { get; set; }
        public required int Year { get; set; }
    }
}
