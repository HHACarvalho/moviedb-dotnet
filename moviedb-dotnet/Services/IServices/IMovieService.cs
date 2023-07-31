namespace moviedb_dotnet.Services.IServices
{
    public interface IMovieService
    {
        string CreateMovie();
        string FindOneMovie(string id);
        void FindMovies();
        void FindAllMovies();
        void UpdateMovie(string id);
        void DeleteMovie(string id);
    }
}
