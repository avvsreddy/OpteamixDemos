using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductCatelogService.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string ProductName { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        [MaxLength(50)]
        public string? Category { get; set; }
        public bool InStock { get; set; }
    }
}
