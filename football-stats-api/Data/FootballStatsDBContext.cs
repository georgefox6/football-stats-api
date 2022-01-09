using Microsoft.EntityFrameworkCore;

namespace football_stats_api.Data
{
    public class FootballStatsDBContext : DbContext
    {
        public FootballStatsDBContext(DbContextOptions<FootballStatsDBContext> options)
            : base(options)
        {
        }

        public DbSet<football_stats_api.Models.Player> Player { get; set; }
    }
}
