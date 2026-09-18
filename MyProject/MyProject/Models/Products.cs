using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Image {  get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0,100000)]
        public double Price { get; set; }


    }
}
