using System.ComponentModel.DataAnnotations;

namespace Shop.DTO
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
