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
        public DbSet<football_stats_api.Models.PlayerAttackingPercentile> PlayerAttackingPercentile { get; set; }
        public DbSet<football_stats_api.Models.PlayerPossessionPercentile> PlayerPossessionPercentile { get; set; }
        public DbSet<football_stats_api.Models.PlayerDefendingPercentile> PlayerDefendingPercentile { get; set; }
        public DbSet<football_stats_api.Models.PlayerTraits> PlayerTraits { get; set; }
        public DbSet<football_stats_api.Models.SimilarPlayers> SimilarPlayers { get; set; }
    }
}
