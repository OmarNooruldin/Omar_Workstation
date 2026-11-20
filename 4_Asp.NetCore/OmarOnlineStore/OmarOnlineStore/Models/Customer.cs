using System.ComponentModel.DataAnnotations;

namespace OmarOnlineStore.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phone {  get; set; }  = string.Empty;

        //public int CardItemId { get; set; }
        //public CardItem? CardItem { get; set; }
    }
}
