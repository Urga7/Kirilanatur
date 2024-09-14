using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class User {
        
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; } = "";

        [StringLength(20)]
        public string FirstName { get; set; } = "";

        [StringLength(20)]
        public string LastName { get; set; } = "";
        
        // TODO
        [StringLength(50)]
        public string Password { get; set; } = "";
        
        public int AddressId { get; set; }
        
        // Navigation Properties
        public Address? Address { get; set; }

    }
    
}
