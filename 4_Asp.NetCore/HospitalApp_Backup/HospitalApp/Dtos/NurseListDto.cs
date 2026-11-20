namespace HospitalApp.Dtos
{
    public class NurseListDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public string Speciality { get; set; }

        public int Salary { get; set; }

        public string DepartmentName { get; set; }
    }

    public class NurseCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public string Speciality { get; set; }

        public int Salary { get; set; }

        public int DepartmentId { get; set; }
    }

    public class NurseUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
