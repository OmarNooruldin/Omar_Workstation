using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Dtos
{
    public class PrescriptionListDto
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; } 
        public string Frequency { get; set; }
        public int DurationDays { get; set; }
        public string ElectronicHealthRecordDiagnosis { get; set; }
    }

    public class PrescriptionCreateDto
    {
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public int DurationDays { get; set; }
        public int ElectronicHealthRecordId { get; set; }
    }


    public class PrescriptionUpdateDto : PrescriptionCreateDto
    {
        public int Id { get; set; }
    }
}
