using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Yess.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = "";
        
    }
}
