using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace HospitalApplication.Models
{
    public class ElectronicHealthRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "Diagnosis ?")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Write the diagonsis to hava a good history about the patient")]
        [Display(Name = "Diagnosis")]
        public string Diagnosis { get; set; } = string.Empty;


        [Required(ErrorMessage = "What are the Symptoms ?")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Write all the symptoms to hava a good history about the patient")]
        [Display(Name = "Symptoms of the Patient")]
        public string Symptoms { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Write all the Notes to hava a good history about the patient")]
        [Display(Name = "Any Notes")]
        public string? Notes { get; set; }

        public ICollection<Prescription>? Prescriptions { get; set; }
    }
}
