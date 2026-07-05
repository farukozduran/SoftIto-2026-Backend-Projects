using System;

namespace Web.Dapper.Hospital.Project.Entity.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorFullName { get; set; } = string.Empty;
        public string PatientFullName { get; set; } = string.Empty;
        public string HospitalName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
