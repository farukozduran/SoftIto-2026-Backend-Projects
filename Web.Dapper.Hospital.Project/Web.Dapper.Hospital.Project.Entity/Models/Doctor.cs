using System;

namespace Web.Dapper.Hospital.Project.Entity.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string HospitalName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
