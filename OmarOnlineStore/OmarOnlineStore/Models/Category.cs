using System.ComponentModel.DataAnnotations;

namespace OmarOnlineStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}