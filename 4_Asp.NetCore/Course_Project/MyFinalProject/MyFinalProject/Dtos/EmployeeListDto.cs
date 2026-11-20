namespace MyFinalProject.dtos
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
    }

    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
    }

    public class EmployeeUpdateDto : EmployeeCreateDto
    {
        public int Id { get; set; }
    }


}
