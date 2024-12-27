using System.ComponentModel.DataAnnotations;

namespace Yess.Models
{
    public class ProductDto
    {
        [Required,MaxLength(100)]
        public string ProductName { get; set; } = "";
        
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = "";
    }
}
