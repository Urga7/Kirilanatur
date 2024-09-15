using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Kirilanatur.Server.Database.Models {
    
    public class User : IdentityUser {
        
        [StringLength(20)]
        public string FirstName { get; set; } = "";

        [StringLength(20)]
        public string LastName { get; set; } = "";
        
        public int? AddressId { get; set; }
        
        // Navigation Properties
        public Address? Address { get; set; }

    }
    
}
