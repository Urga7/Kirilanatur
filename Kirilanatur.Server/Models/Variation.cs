using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Models {
    
    public class Variation {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? CategoryId { get; set; }
        
        // Navigation Properties
        public ProductCategory Category { get; set; }
        
        public List<VariationOption> Options { get; set; }
        
    }
    
}
