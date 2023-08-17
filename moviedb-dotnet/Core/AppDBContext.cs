using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Domain;

namespace moviedb_dotnet.Core
{
    public class AppDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "movieDbAspNet");
        }
    }
}
