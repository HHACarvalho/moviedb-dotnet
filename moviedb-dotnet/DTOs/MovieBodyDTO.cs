namespace moviedb_dotnet.DTOs
{
    public class MovieBodyDTO
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public MovieBodyDTO(string title, string director, int year)
        {
            Title = title;
            Director = director;
            Year = year;
        }
    }
}
