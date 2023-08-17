using System.ComponentModel.DataAnnotations;

namespace moviedb_dotnet.Domain
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movie(string title, string director, int year)
        {
            Id = Guid.NewGuid();
            Title = title;
            Director = director;
            Year = year;
        }
    }
}
