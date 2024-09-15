using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class OrderLine {
        
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int ProductItemId { get; set; }

        public int ShopOrderId { get; set; }
        
        // Navigation Properties
        public ProductItem? ProductItem { get; set; }

        public ShopOrder? ShopOrder { get; set; }
        
    }
    
}
