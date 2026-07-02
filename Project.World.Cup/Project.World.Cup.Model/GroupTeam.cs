using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class GroupTeam
    {
        [Key]
        public int GroupTeamId { get; set; }
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Team? Team { get; set; }
    }
}
