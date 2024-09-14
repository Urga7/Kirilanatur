using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class VariationOption {

        [Key]
        public int Id { get; set; }

        public int? VariationId { get; set; }
        
        // Navigation Properties
        public Variation? Variation { get; set; }

        public List<ProductConfiguration> ProductConfigurations { get; set; } = [];
        
        public List<VariationOptionTranslation> Translations { get; set; } = [];

    }
    
}
