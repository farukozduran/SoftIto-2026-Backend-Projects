using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [StringLength(10)]
        public string GroupName { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament? Tournament { get; set; }
        public virtual ICollection<GroupTeam> GroupTeams { get; set; } = new List<GroupTeam>();
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
