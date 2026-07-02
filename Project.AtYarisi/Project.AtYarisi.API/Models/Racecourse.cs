using System.ComponentModel.DataAnnotations;

namespace Project.AtYarisi.API.Models
{
    public class Racecourse
    {
        [Key]
        public int RacecourseId { get; set; }
        public string FacilityName { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public string SurfaceType { get; set; }
    }
}
