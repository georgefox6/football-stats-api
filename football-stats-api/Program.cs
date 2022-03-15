using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using football_stats_api.Data;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
          builder =>
          {
              builder.WithOrigins("https://www.football-stats.uk",
                                  "https://delightful-ocean-01cb0e303.1.azurestaticapps.net",
                                  "http://localhost:3000",
                                  "http://localhost:8080")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
          });
});

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

builder.Services.AddDbContext<FootballStatsDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("FootballStatsDBContext"), serverVersion));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
