using System.ComponentModel.DataAnnotations;

namespace OmarOnlineStore.Models
{
    public class CardItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public double? TotalPrice { get; set; }

        //public ICollection<Product>? products { get; set; }
    }
}
