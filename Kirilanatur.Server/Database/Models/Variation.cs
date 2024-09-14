using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class Variation {

        [Key]
        public int Id { get; set; }

        public int? CategoryId { get; set; }
        
        // Navigation Properties
        public ProductCategory? Category { get; set; }

        public List<VariationOption> Options { get; set; } = [];
        
        public List<VariationTranslation> Translations { get; set; } = [];

    }
    
}
