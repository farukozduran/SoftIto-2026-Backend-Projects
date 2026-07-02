using System.ComponentModel.DataAnnotations;

namespace CafeManagementAdoNet.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Pozisyon zorunludur.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Maaş zorunludur.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}
