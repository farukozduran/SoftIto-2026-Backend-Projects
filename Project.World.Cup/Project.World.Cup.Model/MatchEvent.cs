using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class MatchEvent
    {
        [Key]
        public int MatchEventId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventType { get; set; }

        [StringLength(100)]
        public string? PlayerName { get; set; }
        public int? EventMinute { get; set; }
        public virtual Match? Match { get; set; }
        public virtual Team? Team { get; set; }
    }
}
