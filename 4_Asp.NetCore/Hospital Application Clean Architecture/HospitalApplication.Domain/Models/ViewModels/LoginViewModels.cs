using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Domain.Models.ViewModels
{
    public class LoginViewModels
    {

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = false;
    
    }
}
