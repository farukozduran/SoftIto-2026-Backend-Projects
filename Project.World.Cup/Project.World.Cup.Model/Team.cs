using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [StringLength(20)]
        public string TeamName { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortCode { get; set; }

        [StringLength(500)]
        public string? FlagUrl { get; set; }

        [StringLength(100)]
        public string? CoachName { get; set; }

        public virtual ICollection<GroupTeam> GroupTeams { get; set; }
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }
    }
}
