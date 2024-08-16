using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Models {
    
    public class ProductConfiguration {

        public int ProductItemId { get; set; }
        
        public int VariationOptionId { get; set; }
        
        // Navigation Properties
        public ProductItem ProductItem { get; set; }

        public VariationOption VariationOption { get; set; }

    }
    
}
