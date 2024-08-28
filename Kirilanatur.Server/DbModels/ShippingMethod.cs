using System.ComponentModel.DataAnnotations;
using Kirilanatur.Server.Shared;

namespace Kirilanatur.Server.DbModels {
    
    public class ShippingMethod {
        
        [Key]
        public int Id { get; set; }
        
        public ShippingMethodOption ShippingMethodOption { get; set; }
        
    }
    
}
