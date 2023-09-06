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
        private readonly HttpClient _http;
        private readonly IMovieRepo _repo;

        public MovieService(HttpClient http, IMovieRepo repo)
        {
            _http = http;
            _repo = repo;
        }

        private async Task CheckPermissions(string? jwt)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:3000/validation/movie");
            request.Headers.Add("Cookie", "token=" + jwt);

            var result = await _http.SendAsync(request);
            result.EnsureSuccessStatusCode();
        }

        public async Task<Result<MovieDTO>> CreateMovie(string? jwt, MovieRequestBody dto)
        {
            await CheckPermissions(jwt);

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

        public async Task<Result<List<MovieDTO>>> FindAllMovies(int pageNumber, int pageSize)
        {
            var movieList = await _repo.FindAll(pageNumber != 0 ? pageNumber : 1, pageSize != 0 ? pageSize : 20);
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("There are no movies");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<MovieDTO>> UpdateMovie(string? jwt, MovieRequestBody dto, string id)
        {
            await CheckPermissions(jwt);

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

        public async Task<Result<MovieDTO>> DeleteMovie(string? jwt, string id)
        {
            await CheckPermissions(jwt);

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
