using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Domain.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LicenseNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Speciality { get; set; } = string.Empty;

        public decimal? ConsultationFee { get; set; }

        //public DateTime AdmitDate DEFAULT GETDATE();
        // Foreign Key
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        //Navigation Properties
        public ICollection<Appointment>? Appointments { get; set; }

    }

}

