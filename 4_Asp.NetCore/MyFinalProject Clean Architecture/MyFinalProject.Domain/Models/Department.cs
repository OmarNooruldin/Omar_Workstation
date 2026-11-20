using System.ComponentModel.DataAnnotations;

namespace MyFinalProject.Domain
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Employee>? Employees { get; set; }
    }
}
