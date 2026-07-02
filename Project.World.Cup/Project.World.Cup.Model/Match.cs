using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public int? GroupId { get; set; }
        public int? StadiumId { get; set; }
        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }
        public DateTime? MatchDate { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int? HomePenaltyScore { get; set; }
        public int? AwayPenaltyScore { get; set; }

        [Required]
        [StringLength(50)]
        public string MatchStage { get; set; } = "Group";

        [Required]
        [StringLength(30)]
        public string MatchStatus { get; set; } = "Scheduled";
        public virtual Tournament? Tournament { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Stadium? Stadium { get; set; }
        public virtual Team? HomeTeam { get; set; }
        public virtual Team? AwayTeam { get; set; }
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }
    }
}
