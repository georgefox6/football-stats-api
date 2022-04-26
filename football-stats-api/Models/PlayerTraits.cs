using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("player_traits")]
    public class PlayerTraits
    {
        public int Id { get; set; }

        public int? PlayerId { get; set; }


        public bool? LongShotTaker { get; set; }
        public bool? SneakyFouler { get; set; }
        public bool? PressingForward { get; set; }
        public bool? ProlificDribbler { get; set; }
        public bool? GoodInTheAir { get; set; }
        public bool? DirtyPlayer { get; set; }
        public bool? SafeOnTheBall { get; set; }
        public bool? Stamina { get; set; }
        public bool? ClinicalFinisher { get; set; }
    }
}
