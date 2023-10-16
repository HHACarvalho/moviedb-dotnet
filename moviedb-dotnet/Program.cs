using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Repos;
using moviedb_dotnet.Repos.IRepos;
using moviedb_dotnet.Services;
using moviedb_dotnet.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// CUSTOM

builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddTransient<IMovieRepo, MovieRepo>();
builder.Services.AddTransient<IMovieService, MovieService>();

// CUSTOM

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
