﻿using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Models { 
    
    public class ProductImage {
    
        public int Id { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        public int ProductId { get; set; }
        
        public Product Product { get; set; }
        
    }
    
}