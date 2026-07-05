using System;

namespace Web.Dapper.Hospital.Project.Entity.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
