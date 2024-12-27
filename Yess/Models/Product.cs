﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Yess.Models
{
    public class Product

    {
        [Key]
        public int ProductId { get; set; }

        [Required,MaxLength(100)]
        public string ProductName { get; set; } = "";

        [Required]
        public int CategoryId { get; set; }

        
        public string CategoryName { get; set; } = "";

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; } 
    }
}
