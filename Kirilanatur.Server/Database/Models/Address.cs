using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class Address {
        
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Street { get; set; } = "";

        [StringLength(20)]
        public string HouseNumber { get; set; } = "";
        
        [StringLength(50)]
        public string City { get; set; } = "";

        [StringLength(20)]
        public string PostalCode { get; set; } = "";

        public int CountryId { get; set; }
        
        // Navigation Properties
        public Country? Country { get; set; }

    }
    
}
