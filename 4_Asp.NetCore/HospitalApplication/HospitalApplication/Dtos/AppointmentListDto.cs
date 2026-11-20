using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Dtos
{
    public class AppointmentListDto
    {
        public int Id { get; set; } 
        public DateTime AppointmentDate { get; set; }

        public string ReasonForVisit { get; set; }

        public string Status { get; set; }

        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
    }

    public class AppointmentCreateDto
    {
        public DateTime AppointmentDate { get; set; }

        public string ReasonForVisit { get; set; }

        public string Status { get; set; }

        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

    }

    public class AppointmentUpdateDto : AppointmentCreateDto
    {
        public int Id { get; set; }
    }
}
