using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Dtos
{
    public class BillingListDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string? InsuranceProvider { get; set; } 
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
    }

    public class BillingCreateDto
    {
        public decimal TotalAmount { get; set; }
        public string? InsuranceProvider { get; set; }
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        //public DateTime CreateBill {  get; set; }
    }

    //public class BillingUpdateDto
    //{
    //    public int Id { get; set; }
    //    public decimal TotalAmount { get; set; }
    //    public string? InsuranceProvider { get; set; }
    //    public int AppointmentId { get; set; }
    //    public int? PatientId { get; set; }
    //    //public DateTime UpdateBill { get; set; }
    //}
}
