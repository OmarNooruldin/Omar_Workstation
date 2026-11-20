using System.ComponentModel.DataAnnotations;

namespace OmarOnlineStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; } = decimal.Zero;

        public string? Image { get; set; } = string.Empty;

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
