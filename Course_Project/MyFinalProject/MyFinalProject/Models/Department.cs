using System.ComponentModel.DataAnnotations;

namespace MyFinalProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public required ICollection<Employee> Employees { get; set; }
    }
}
