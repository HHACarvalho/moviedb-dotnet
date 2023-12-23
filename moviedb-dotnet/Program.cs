using Microsoft.EntityFrameworkCore;
using moviedb_dotnet.Core.Infrastructure;
using moviedb_dotnet.Repos;
using moviedb_dotnet.Repos.IRepos;
using moviedb_dotnet.Services;
using moviedb_dotnet.Services.IServices;

var corsPolicyName = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
});

builder.Services.AddTransient<IMovieRepo, MovieRepo>();
builder.Services.AddTransient<IMovieService, MovieService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
