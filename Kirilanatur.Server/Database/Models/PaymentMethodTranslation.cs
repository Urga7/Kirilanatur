using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class PaymentMethodTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        [StringLength(50)]
        public string Description { get; set; } = "";

        public int PaymentMethodId { get; set; }
        
        // Navigation Properties
        public PaymentMethod? PaymentMethod { get; set; }

    }
    
}
