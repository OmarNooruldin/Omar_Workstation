using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Dtos
{
    public class DoctorListDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public string Speciality { get; set; }

        public decimal? ConsultationFee { get; set; }

        public int Salary { get; set; }     

        public string DepartmentName { get; set; }
    }

    public class DoctorCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public string Speciality { get; set; }

        public decimal? ConsultationFee { get; set; }

        public int Salary { get; set; }

        public int DepartmentId { get; set; }
    }

    public class DoctorUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
