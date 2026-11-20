using System.ComponentModel.DataAnnotations;

namespace MyFinalProject.Application.Dtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
    }

    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductUpdateDto : ProductCreateDto
    {
        public int Id { get; set; }
    }
}
