using System.ComponentModel.DataAnnotations;
using Kirilanatur.Server.Shared;

namespace Kirilanatur.Server.DbModels {
    
    public class OrderStatus {
        
        [Key]
        public int Id { get; set; }
        
        public OrderStatusType OrderStatusType { get; set; }
        
    }
    
}
