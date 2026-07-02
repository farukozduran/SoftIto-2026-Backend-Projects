using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }

        [Required]
        [StringLength(20)]
        public string TournamentName { get; set; }

        public int Year { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
