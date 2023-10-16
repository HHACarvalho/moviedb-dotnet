using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Domain;
using moviedb_dotnet.DTOs;
using moviedb_dotnet.Mappers;
using moviedb_dotnet.Repos.IRepos;
using moviedb_dotnet.Services.IServices;

namespace moviedb_dotnet.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _repo;

        public MovieService(IMovieRepo repo)
        {
            _repo = repo;
        }

        public async Task<Result<MovieDTO>> CreateMovie(MovieRequestBody dto)
        {
            var movie = new Movie(dto.Title, dto.Director, dto.Poster, dto.Synopsis, dto.Year);

            await _repo.Create(movie);

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<List<MovieDTO>>> FindAllMovies(int pageNumber, int pageSize)
        {
            var movieList = await _repo.FindAll(pageNumber != 0 ? pageNumber : 1, pageSize != 0 ? pageSize : 20);
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("There are no movies");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<List<MovieDTO>>> FindMovies(string movieTitle)
        {
            var movieList = await _repo.Find(movieTitle);
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("No movies with " + movieTitle + " in the title were found");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<MovieDTO>> FindOneMovie(string movieId)
        {
            var movie = await _repo.FindOne(movieId);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("No movie with the id '" + movieId + "' was found");
            }

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<MovieDTO>> UpdateMovie(string movieId, MovieRequestBody dto)
        {
            var movie = await _repo.FindOne(movieId);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("No movie with the id '" + movieId + "' was found");
            }

            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Poster = dto.Poster;
            movie.Synopsis = dto.Synopsis;
            movie.Year = dto.Year;

            await _repo.CommitChanges();

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<MovieDTO>> DeleteMovie(string movieId)
        {
            var movie = await _repo.FindOne(movieId);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("No movie with the id '" + movieId + "' was found");
            }

            await _repo.Delete(movie);

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }
    }
}
