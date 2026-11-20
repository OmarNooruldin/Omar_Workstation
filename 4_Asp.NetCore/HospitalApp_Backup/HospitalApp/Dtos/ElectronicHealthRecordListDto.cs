using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Dtos
{
    public class ElectronicHealthRecordListDto
    {
        public int Id { get; set; }

        public DateTime VisitDate { get; set; }

        public string Diagnosis { get; set; } 

        public string Symptoms { get; set; } 

        public string? Notes { get; set; }

        public int? PatientId { get; set; }
    }

    public class ElectronicHealthRecordCreateDto
    {
        public DateTime VisitDate { get; set; }

        public string Diagnosis { get; set; }

        public string Symptoms { get; set; }

        public string? Notes { get; set; }

        public int? PatientId { get; set; }
    }

    public class ElectronicHealthRecordUpdateDto : ElectronicHealthRecordCreateDto
    {
        public int Id { get; set; }
    }
}
