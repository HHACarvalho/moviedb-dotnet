using moviedb_dotnet.Core.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace moviedb_dotnet.Domain
{
    public class Movie(string director, string title, string poster, string synopsis, int year) : Entity
    {
        [MaxLength(96)]
        public string Title { get; set; } = title;

        [MaxLength(48)]
        public string Director { get; set; } = director;

        [MaxLength(256)]
        public string Poster { get; set; } = poster;

        [MaxLength(512)]
        public string Synopsis { get; set; } = synopsis;

        [Range(1888, int.MaxValue)]
        public int Year { get; set; } = year;
    }
}
