using moviedb_dotnet.Domain;
using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Mappers
{
    public class MovieMapper
    {
        public static MovieDTO toDTO(Movie movie)
        {
            return new MovieDTO { Title = movie.Title, Director = movie.Director, Year = movie.Year };
        }
    }
}
