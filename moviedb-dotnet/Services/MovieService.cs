using moviedb_dotnet.Services.IServices;
using System.Diagnostics;

namespace moviedb_dotnet.Services
{
    public class MovieService : IMovieService
    {
        public string CreateMovie()
        {
            Debug.WriteLine("HAHAHA");
            return "Created movie";
        }

        public string FindOneMovie(string id)
        {
            return "Find one movie";
        }

        public void FindMovies()
        {
            throw new NotImplementedException();
        }

        public void FindAllMovies()
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }
    }
}
