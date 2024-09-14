using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ProductImageTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        [StringLength(100)]
        public string Description { get; set; } = "";
        
        public int ProductImageId { get; set; }
        
        // Navigation Properties
        public ProductImage? ProductImage { get; set; }

    }
    
}
