using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ShippingMethodTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        public string Description { get; set; } = "";

        public int ShippingMethodId { get; set; }
        
        // Navigation Properties
        public ShippingMethod? ShippingMethod { get; set; }

    }
    
}
