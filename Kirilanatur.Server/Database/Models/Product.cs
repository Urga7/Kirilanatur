using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models { 
    
    public class Product {
        
        [Key]
        public int Id { get; set; }
        
        public int Price { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        public bool Available { get; set; } = true;

        public int? CategoryId { get; set; }

        // Navigation Properties
        public ProductCategory? Category { get; set; }

        public List<ProductItem> ProductItems { get; set; } = [];
        public List<ProductImage> Images { get; set; } = [];
        
        public List<ProductTranslation> Translations { get; set; } = [];

    }
}

