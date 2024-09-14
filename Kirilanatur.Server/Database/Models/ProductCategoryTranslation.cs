using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ProductCategoryTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        [StringLength(50)]
        public string Name { get; set; } = "";
        
        public int ProductCategoryId { get; set; }
        
        // Navigation Properties
        public ProductCategory? ProductCategory { get; set; }

    }
    
}
