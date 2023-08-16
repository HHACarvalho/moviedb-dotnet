using moviedb_dotnet.Core.Domain;

namespace moviedb_dotnet.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movie(EntityID? id, string title, string director, int year) : base(id)
        {
            Title = title;
            Director = director;
            Year = year;
        }
    }
}
