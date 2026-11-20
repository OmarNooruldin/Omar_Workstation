using System.ComponentModel.DataAnnotations;

namespace HosApp.Models
{
    public class ElectronicHealthRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        public string Diagnosis { get; set; } = string.Empty;


        [Required]
        public string Symptoms { get; set; } = string.Empty;


        public string? Notes { get; set; }

        public ICollection<Prescription>? Prescriptions { get; set; }
    }
}
