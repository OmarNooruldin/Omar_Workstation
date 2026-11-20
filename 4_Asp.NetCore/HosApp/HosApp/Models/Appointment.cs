using System.ComponentModel.DataAnnotations;

namespace HosApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        public string ReasonForVisit { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
