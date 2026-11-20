using System.ComponentModel.DataAnnotations;

namespace HosApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Doctor>? Doctors { get; set; }
    }
}
