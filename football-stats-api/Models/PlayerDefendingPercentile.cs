using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("player_defending_percentile")]
    public class PlayerDefendingPercentile
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int? TacklesWonPercentile { get; set; }
        public int? BlocksPercentile { get; set; }
        public int? InterceptionsPercentile { get; set; }
        public int? PressuresPercentile { get; set; }
        public int? HeadersWonPercentile { get; set; }

        public int? TacklesWonPer90Percentile { get; set; }
        public int? BlocksPer90Percentile { get; set; }
        public int? InterceptionsPer90Percentile { get; set; }
        public int? PressuresPer90Percentile { get; set; }
        public int? HeadersWonPer90Percentile { get; set; }

        public int? TacklesWonPerPositionPercentile { get; set; }
        public int? BlocksPerPositionPercentile { get; set; }
        public int? InterceptionsPerPositionPercentile { get; set; }
        public int? PressuresPerPositionPercentile { get; set; }
        public int? HeadersWonPerPositionPercentile { get; set; }

        public int? TacklesWonPer90PerPositionPercentile { get; set; }
        public int? BlocksPer90PerPositionPercentile { get; set; }
        public int? InterceptionsPer90PerPositionPercentile { get; set; }
        public int? PressuresPer90PerPositionPercentile { get; set; }
        public int? HeadersWonPer90PerPositionPercentile { get; set; }
    }
}
