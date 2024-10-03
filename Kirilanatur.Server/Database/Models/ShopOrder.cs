using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ShopOrder {
        
        [Key]
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }

        public int OrderTotal { get; set; }

        public string UserId { get; set; } = "";

        public int StatusId { get; set; }
        
        public int ShippingMethodId { get; set; }

        public int PaymentMethodId { get; set; }
        
        // Navigation properties
        public KirilanaturUser? User { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public ShippingMethod? ShippingMethod { get; set; }

        public List<OrderLine> OrderLines { get; set; } = [];

    }
    
}
