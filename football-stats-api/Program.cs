using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using football_stats_api.Data;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

builder.Services.AddDbContext<FootballStatsDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("FootballStatsDBContext"), serverVersion));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
