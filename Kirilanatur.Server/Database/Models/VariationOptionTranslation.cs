using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class VariationOptionTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        [StringLength(50)]
        public string Label { get; set; } = "";

        [StringLength(30)]
        public string Value { get; set; } = "";

        public int VariationOptionId { get; set; }
        
        // Navigation Properties
        public VariationOption? VariationOption { get; set; }

    }
    
}
