using System.ComponentModel.DataAnnotations;

namespace Shop.DTO
{
    public class ProductFilterDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter correct value(more then 1)")]
        public int pageIndex { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter correct value(more then 1)")]
        public int pageSize { get; set; }

        [Required]
        public SortField sortField { get; set; }

        [Required]
        public Sort sort { get; set; }
    }
    public enum SortField{
        name,
        price,
    }
    public enum Sort
    {
        asc,
        desc,
    }
}
