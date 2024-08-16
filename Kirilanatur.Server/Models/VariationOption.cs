using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Models {
    
    public class VariationOption {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Value { get; set; }

        public int? VariationId { get; set; }
        
        // Navigation Properties
        public Variation Variation { get; set; }

        public List<ProductConfiguration> ProductConfigurations { get; set; }
        
    }
    
}
