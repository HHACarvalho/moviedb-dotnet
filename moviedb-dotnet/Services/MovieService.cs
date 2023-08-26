using moviedb_dotnet.Core;
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
            var movie = new Movie(dto.Title, dto.Director, dto.Year);

            await _repo.Create(movie);

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<MovieDTO>> FindOneMovie(string id)
        {
            var movie = await _repo.FindOne(id);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("No movie with the id '" + id + "' was found");
            }

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<List<MovieDTO>>> FindMovies(string title)
        {
            var movieList = await _repo.Find(title);
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("No movies with " + title + " in the title were found");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<List<MovieDTO>>> FindAllMovies()
        {
            var movieList = await _repo.FindAll();
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("There are no movies");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<MovieDTO>> UpdateMovie(MovieRequestBody dto, string id)
        {
            var movie = await _repo.FindOne(id);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("No movie with the id '" + id + "' was found");
            }

            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Year = dto.Year;

            await _repo.CommitChanges();

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<MovieDTO>> DeleteMovie(string id)
        {
            var movie = await _repo.FindOne(id);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("No movie with the id '" + id + "' was found");
            }

            await _repo.Delete(movie);

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }
    }
}
