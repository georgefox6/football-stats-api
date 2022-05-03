﻿using System.ComponentModel.DataAnnotations.Schema;

namespace football_stats_api.Models
{
    [Table("similar_players")]
    public class SimilarPlayers
    {
        //General
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int Player3 { get; set; }
        public int Player4 { get; set; }
        public int Player5 { get; set; }   
        public int Player6 { get; set; }   
        public int Player7 { get; set; }   
        public int Player8 { get; set; }   
        public int Player9 { get; set; }   
        public int Player10 { get; set; }   
    }
}