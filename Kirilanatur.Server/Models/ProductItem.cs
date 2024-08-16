using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Models {
    
    public class ProductItem {
        
        [Key]
        public int Id { get; set; }
        
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public int? ProductId { get; set; }

        // Navigation Properties
        public Product Product { get; set; }

        public List<ProductConfiguration> ProductConfigurations { get; set; }
        
    }
    
}
