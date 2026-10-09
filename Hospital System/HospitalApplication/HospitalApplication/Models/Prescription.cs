using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string MedicineName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Dosage { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Frequency { get; set; } = string.Empty;

        [Required]
        public int DurationDays { get; set; }


        public int ElectronicHealthRecordId { get; set; }
        public ElectronicHealthRecord? ElectronicHealthRecord { get; set; }
    }
}
