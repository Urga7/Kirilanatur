using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ShoppingCart {
        
        [Key]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        // Navigation Properties
        public User? User { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = [];

    }
    
}
