using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.DbModels { 
    
    public class ProductImage {
    
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string ImageUrl { get; set; } = "";

        public int? ProductId { get; set; }
        
        // Navigation Properties
        public Product? Product { get; set; }
        
    }
    
}