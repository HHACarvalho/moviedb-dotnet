using moviedb_dotnet.Services;
using moviedb_dotnet.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

//Custom

builder.Services.AddTransient<IMovieService, MovieService>();

//Custom

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
