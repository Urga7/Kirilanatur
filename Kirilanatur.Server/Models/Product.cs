using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Models { 
    
    public class Product {
        
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Range(0, 100)]
        public int Discount { get; set; }
        
        public bool Availability { get; set; }

        public int? CategoryId { get; set; }

        // Navigation Properties
        public ProductCategory Category { get; set; }

        public List<ProductItem> ProductItems { get; set; }
        public List<ProductImage> Images { get; set; }

    }
}

