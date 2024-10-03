using System.ComponentModel.DataAnnotations;
using Kirilanatur.Server.Shared;

namespace Kirilanatur.Server.Database.Models {
    
    public class ShippingMethod {
        
        [Key]
        public int Id { get; set; }
        
        public ShippingMethodOption ShippingMethodOption { get; set; }
        
        // Navigation Properties
        public List<ShippingMethodTranslation> Translations { get; set; } = [];
        
        public List<ShopOrder> ShopOrders { get; set; } = [];

    }
    
}
