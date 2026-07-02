using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.World.Cup.Model
{
    public class Stadium
    {
        [Key]
        public int StadiumId { get; set; }

        [Required]
        [StringLength(50)]
        public string StadiumName { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        public int? Capacity { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

    }
}
