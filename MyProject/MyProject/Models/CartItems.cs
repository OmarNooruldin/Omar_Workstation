using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class CartItems
    {
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
