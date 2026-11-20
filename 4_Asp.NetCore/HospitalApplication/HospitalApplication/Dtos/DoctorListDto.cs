using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Dtos
{
    public class DoctorListDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public string Speciality { get; set; }

        public decimal? ConsultationFee { get; set; }

        public int DepartmentName { get; set; }
    }

    public class DoctorCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public string Speciality { get; set; }

        public decimal? ConsultationFee { get; set; }

        public int DepartmentId { get; set; }
    }

    public class DoctorUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
    }
}
