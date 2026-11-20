using System.ComponentModel.DataAnnotations;

namespace HosApp.Models
{
    public class Billing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal TotalAmount { get; set; } = 0;

        public string? InsuranceProvider { get; set; }

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
