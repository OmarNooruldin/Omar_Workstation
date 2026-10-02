using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Specialization { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //public List<WorkShift> Schedule { get; set; } = new();
        //public StaffRole Role { get; set; }
        //public string passwordHasher { get; set; }
    }

    //public class WorkShift() 
    //{
    //    public int Id { get; set; }
    //    public DayOfWeek DayOfWeek { get; set; }

    //    // Using TimeOnly (introduced in .NET 6) for pure time tracking
    //    public TimeOnly StartTime { get; set; }
    //    public TimeOnly EndTime { get; set; }

    //    // Optional: Link to the parent entity
    //    public int? StaffId { get; set; }
    //    public Staff? Staff { get; set; }
    //}
}


