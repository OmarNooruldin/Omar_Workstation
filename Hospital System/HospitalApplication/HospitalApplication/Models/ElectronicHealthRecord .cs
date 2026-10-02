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

        [Required(ErrorMessage = "What are the Symptoms ?")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Write all the symptoms to hava a good history about the patient")]
        [Display(Name = "Symptoms of the Patient")]
        public string symptoms { get; set; } = string.Empty;

        [Required(ErrorMessage = "Diagnosis ?")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Write the diagonsis to hava a good history about the patient")]
        [Display(Name = "Diagnosis")]
        public string Diagnosis { get; set; } = string.Empty;

        public int PatientId {  get; set; }
        public required Patient Patient { get; set; }

        public int StaffId { get; set; }
        public required Staff Staff { get; set; }

        //public List<PrescriptionItem> Items { get; set; } = new List<PrescriptionItem>();
    }
}
