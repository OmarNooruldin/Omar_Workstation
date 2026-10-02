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

        public int PatientId { get; set; }
        public required Patient Patient { get; set; }

        public int StaffId { get; set; }
        public required Staff Staff { get; set; }



        //public BookingStatus Status { get; set; } = BookingStatus.Pending;

        //public int PatientId { get; set; }
        //[ForeignKey("PatientId")]
        //public virtual Patient Patient { get; set; }
    }
}
