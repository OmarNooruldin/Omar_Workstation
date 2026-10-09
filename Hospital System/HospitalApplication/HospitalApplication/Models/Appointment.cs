using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Reason for visit is required.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "The reason must be between 5 and 500 characters.")]
        [Display(Name = "Reason for Visit")]
        public string ReasonForVisit { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public string DoctorName { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        //public int DoctorId { get; set; }
        //public Doctor? Doctor { get; set; }
    }
}
