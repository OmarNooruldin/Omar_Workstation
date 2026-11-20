using System.ComponentModel.DataAnnotations;

namespace OmarOnlineStore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = false;
    
    }
}
