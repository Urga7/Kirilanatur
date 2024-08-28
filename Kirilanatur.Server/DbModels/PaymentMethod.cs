using System.ComponentModel.DataAnnotations;
using Kirilanatur.Server.Shared;

namespace Kirilanatur.Server.DbModels {
    
    public class PaymentMethod {
        
        [Key]
        public int Id { get; set; }
        
        public PaymentMethodOption PaymentMethodOption { get; set; }
        
    }
    
}
