using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class VariationTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        [StringLength(50)]
        public string Name { get; set; } = "";
        
        public int VariationId { get; set; }
        
        // Navigation Properties
        public Variation? Variation { get; set; }

    }
    
}
