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
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string? Address { get; set; }

        public string? City { get; set; }
        [StringLength(12)]
        public string? Phone { get; set; }
        [Required]
        [Range(2500,15000,ErrorMessage = "Salary must be between 3000 and 10000.")]
        public int Salary { get; set; } 
    }
}
