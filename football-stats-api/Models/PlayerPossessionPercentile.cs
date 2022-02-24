using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("player_possession_percentile")]
    public class PlayerPossessionPercentile
    {
        public int Id { get; set; }

        public int? PlayerId { get; set; }

        public int? PassesCompletedPercentile { get; set; }
        public int? ProgressivePassingDistancePercentile { get; set; }
        public int? CrossesPercentile { get; set; }
        public int? DribblesPercentile { get; set; }
        public int? ProgressiveDribbleDistancePercentile { get; set; }
        public int? PassesControlledPercentile { get; set; }
        public int? AssistsPercentile { get; set; }
        public int? ExpectedAssistsPercentile { get; set; }

        public int? PassesCompletedPer90Percentile { get; set; }
        public int? ProgressivePassingDistancePer90Percentile { get; set; }
        public int? CrossesPer90Percentile { get; set; }
        public int? DribblesPer90Percentile { get; set; }
        public int? ProgressiveDribbleDistancePer90Percentile { get; set; }
        public int? PassesControlledPer90Percentile { get; set; }
        public int? AssistsPer90Percentile { get; set; }
        public int? ExpectedAssistsPer90Percentile { get; set; }

        public int? PassesCompletedPerPositionPercentile { get; set; }
        public int? ProgressivePassingDistancePerPositionPercentile { get; set; }
        public int? CrossesPerPositionPercentile { get; set; }
        public int? DribblesPerPositionPercentile { get; set; }
        public int? ProgressiveDribbleDistancePerPositionPercentile { get; set; }
        public int? PassesControlledPerPositionPercentile { get; set; }
        public int? AssistsPerPositionPercentile { get; set; }
        public int? ExpectedAssistsPerPositionPercentile { get; set; }

        public int? PassesCompletedPer90PerPositionPercentile { get; set; }
        public int? ProgressivePassingDistancePer90PerPositionPercentile { get; set; }
        public int? CrossesPer90PerPositionPercentile { get; set; }
        public int? DribblesPer90PerPositionPercentile { get; set; }
        public int? ProgressiveDribbleDistancePer90PerPositionPercentile { get; set; }
        public int? PassesControlledPer90PerPositionPercentile { get; set; }
        public int? AssistsPer90PerPositionPercentile { get; set; }
        public int? ExpectedAssistsPer90PerPositionPercentile { get; set; }
    }
}
