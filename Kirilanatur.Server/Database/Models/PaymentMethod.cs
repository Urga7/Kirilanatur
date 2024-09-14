using System.ComponentModel.DataAnnotations;
using Kirilanatur.Server.Shared;

namespace Kirilanatur.Server.Database.Models {
    
    public class PaymentMethod {
        
        [Key]
        public int Id { get; set; }
        
        public PaymentMethodOption PaymentMethodOption { get; set; }
        
        // Navigation Properties
        public List<PaymentMethodTranslation> Translations { get; set; } = [];

    }
    
}
