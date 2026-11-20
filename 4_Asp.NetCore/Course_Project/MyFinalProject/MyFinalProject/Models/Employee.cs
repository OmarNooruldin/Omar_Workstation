using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyFinalProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        public string? Address { get; set; }

        [StringLength(12)]
        public string? Phone { get; set; }

        public string? City { get; set; }
   
        [Required]
        [Range(2500,15000,ErrorMessage = "Salary must be between 3000 and 15000.")]
        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
