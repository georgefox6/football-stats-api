using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("player_attacking_percentile")]
    public class PlayerAttackingPercentile
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public int? GoalsPercentile { get; set; }
        public int? ExpectedGoalsPercentile { get; set; }
        public int? ShotsPercentile { get; set; }
        public int? ShotsOnTargetPercentile { get; set; }
        public int? PenaltyGoalsPercentile { get; set; }
        public int? FreeKickShotsPercentile { get; set; }

        public int? GoalsPer90Percentile { get; set; }
        public int? ExpectedGoalsPer90Percentile { get; set; }
        public int? ShotsPer90Percentile { get; set; }
        public int? ShotsOnTargetPer90Percentile { get; set; }
        public int? PenaltyGoalsPer90Percentile { get; set; }
        public int? FreeKickShotsPer90Percentile { get; set; }

        public int? GoalsPerPositionPercentile { get; set; }
        public int? ExpectedGoalsPerPositionPercentile { get; set; }
        public int? ShotsPerPositionPercentile { get; set; }
        public int? ShotsOnTargetPerPositionPercentile { get; set; }
        public int? PenaltyGoalsPerPositionPercentile { get; set; }
        public int? FreeKickShotsPerPositionPercentile { get; set; }

        public int? GoalsPer90PerPositionPercentile { get; set; }
        public int? ExpectedGoalsPer90PerPositionPercentile { get; set; }
        public int? ShotsPer90PerPositionPercentile { get; set; }
        public int? ShotsOnTargetPer90PerPositionPercentile { get; set; }
        public int? PenaltyGoalsPer90PerPositionPercentile { get; set; }
        public int? FreeKickShotsPer90PerPositionPercentile { get; set; }
    }
}
