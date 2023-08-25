using moviedb_dotnet.Core.Infrastructure;

namespace moviedb_dotnet.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movie(string title, string director, int year)
        {
            Title = title;
            Director = director;
            Year = year;
        }
    }
}
