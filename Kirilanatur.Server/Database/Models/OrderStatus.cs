using System.ComponentModel.DataAnnotations;
using Kirilanatur.Server.Shared;

namespace Kirilanatur.Server.Database.Models {
    
    public class OrderStatus {
        
        [Key]
        public int Id { get; set; }
        
        public OrderStatusType OrderStatusType { get; set; }
        
        // Navigation Properties
        public List<OrderStatusTranslation> Translations { get; set; } = [];
        
        public List<ShopOrder> ShopOrders { get; set; } = [];

    }
    
}
