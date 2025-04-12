﻿using System.ComponentModel.DataAnnotations;

namespace Project_01.Models
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
