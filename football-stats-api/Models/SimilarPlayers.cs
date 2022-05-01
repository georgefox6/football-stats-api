using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("similar_players")]
    public class SimilarPlayers
    {
        //General
        public int Id { get; set; }
        public Player? PlayerId { get; set; }
        public Player? Player1 { get; set; }
        public Player? Player2 { get; set; }
        public Player? Player3 { get; set; }
        public Player? Player4 { get; set; }
        public Player? Player5 { get; set; }   
    }
}
