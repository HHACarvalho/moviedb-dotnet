namespace moviedb_dotnet.DTOs
{
    public class MovieRequestBody
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int Year { get; set; }
    }
}
