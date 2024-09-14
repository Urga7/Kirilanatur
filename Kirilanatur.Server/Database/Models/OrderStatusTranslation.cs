using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class OrderStatusTranslation {
        
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; } = "";

        public string Description { get; set; } = "";

        public int OrderStatusId { get; set; } 
        
        // Navigation Properties
        public OrderStatus? OrderStatus { get; set; }

    }
    
}
