using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("players")]
    public class Player
    {
        //General
        public int id { get; set; }
        public string playerName { get; set; }
        public string? playerNation { get; set; }
        public string? playerPosition { get; set; }
        public string? playerAge { get; set; }
        public string? playerTeam { get; set; }
        public string? imageUrl { get; set; }

        //Playing time
        public int? matchesPlayed { get; set; }
        public int? matchesStarted { get; set; }
        public int? minutesPlayed { get; set; }

        //Performance
        public int? goals { get; set; }
        public int? assists { get; set; }

        //Expected performance
        public double expectedGoals { get; set; }
        public double expectedAssists { get; set; }

        //Shooting
        public int? shots { get; set; }
        public int? shotsOnTarget { get; set; }
        public double shotDistance { get; set; }

        public int? freeKickShots { get; set; }
        public int? penaltyScored { get; set; }
        public int? penaltyShots { get; set; }

        //Passing
        public int? totalPassesAttempted { get; set; }
        public int? totalPassesCompleted { get; set; }
        public int? shortPassesAttempted { get; set; }
        public int? shortPassesCompleted { get; set; }
        public int? mediumPassesAttempted { get; set; }
        public int? mediumPassesCompleted { get; set; }
        public int? LongPassesAttempted { get; set; }
        public int? LongPassesCompleted { get; set; }
        public int? progressivePassingDistance { get; set; }
        public int? crosses { get; set; }


        //Defensive
        public int? tacklesAttempted { get; set; }
        public int? tacklesWon { get; set; }
        public int? tacklesDefensiveThird { get; set; }
        public int? tacklesMiddleThird { get; set; }
        public int? tacklesAttackingThird { get; set; }
        public int? interceptions { get; set; }
        public int? pressuresAttempted { get; set; }
        public int? pressuresWon { get; set; }
        public int? pressuresDefensiveThird { get; set; }
        public int? pressuresMiddleThird { get; set; }
        public int? pressuresAttackingThird { get; set; }
        public int? blocks { get; set; }
        public int? fouls { get; set; }

        //Dribbling
        public int? dribblesAttempted { get; set; }
        public int? dribblesCompleted { get; set; }
        public int? dribblesProgressiveDistance { get; set; }
        public int? progressiveDribbles { get; set; }
        public int? passesReceived { get; set; }
        public int? passesControlled { get; set; }

        //Misc
        public int? yellowCards { get; set; }
        public int? RedCards { get; set; }
        public int? headersWon { get; set; }
        public int? headersLost { get; set; }
        
        //General Transfer
        public int? height { get; set; }
        public string? preferredFoot { get; set; }
        public string? contractEndDate { get; set; }
        public int? marketValue { get; set; }
        public int? wage { get; set; }

        internal PlayerSummary ToSummary()
        {
            return new PlayerSummary
            {
                Id = this.id,
                Name = this.playerName
            };
        }
    }
}
