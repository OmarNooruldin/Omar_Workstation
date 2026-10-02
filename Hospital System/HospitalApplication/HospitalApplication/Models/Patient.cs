using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace HospitalApplication.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string ContactNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string EmergencyContactName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string EmergencyContactPhone { get; set; } = string.Empty;

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime BirthDate { get; set; }

        //[EnumDataType]
        //public enum Gender;

    }
}
