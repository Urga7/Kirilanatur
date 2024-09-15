using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
   
    public class ShoppingCartItem {
    
        [Key]
        public int Id { get; set; }
        
        public int Quantity { get; set; }
        
        public int ProductItemId { get; set; }
        
        public int ShoppingCartId { get; set; }
        
        // Navigation properties
        public ProductItem? ProductItem { get; set; }
        
        public ShoppingCart? ShoppingCart { get; set; }
        
    }
    
}
