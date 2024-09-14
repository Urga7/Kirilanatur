using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ProductTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";
    
        [StringLength(50)]
        public string Name { get; set; } = "";
        
        [StringLength(1000)]
        public string Description { get; set; } = "";

        public int ProductId { get; set; }
        
        // Navigation Properties
        public Product? Product { get; set; }

    }
    
}
