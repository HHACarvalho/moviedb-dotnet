using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Domain;

namespace moviedb_dotnet.Core.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "movieDB");
        }
    }
}
