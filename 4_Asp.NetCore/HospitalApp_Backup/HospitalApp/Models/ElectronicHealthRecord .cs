using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace HospitalApp.Models
{
    public class ElectronicHealthRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "Diagnosis ?")]
        [Display(Name = "Diagnosis")]
        public string Diagnosis { get; set; } = string.Empty;


        [Required(ErrorMessage = "What are the Symptoms ?")]
        [Display(Name = "Symptoms of the Patient")]
        public string Symptoms { get; set; } = string.Empty;


        [Display(Name = "Any Notes")]
        public string? Notes { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
