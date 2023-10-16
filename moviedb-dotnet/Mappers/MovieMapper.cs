using moviedb_dotnet.Domain;
using moviedb_dotnet.DTOs;

namespace moviedb_dotnet.Mappers
{
    public class MovieMapper
    {
        public static MovieDTO ToDTO(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id.ToString(),
                Title = movie.Title,
                Director = movie.Director,
                Poster = movie.Poster,
                Synopsis = movie.Synopsis,
                Year = movie.Year
            };
        }
    }
}
