using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Dtos
{
    public class DepartmentListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentCreateDto
    {
        public string Name { get; set; }
    }

    public class DepartmentUpdateDto : DepartmentCreateDto
    {
        public int Id { get; set; }
    }
}
