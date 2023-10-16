using moviedb_dotnet.Core.Infrastructure;

namespace moviedb_dotnet.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
        public string Synopsis { get; set; }
        public int Year { get; set; }

        public Movie(string title, string director, string poster, string synopsis, int year)
        {
            Title = title;
            Director = director;
            Poster = poster;
            Synopsis = synopsis;
            Year = year;
        }
    }
}
