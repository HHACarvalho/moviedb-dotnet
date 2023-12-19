using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Domain;

namespace moviedb_dotnet.Core.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public AppDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfig());
        }
    }
}
