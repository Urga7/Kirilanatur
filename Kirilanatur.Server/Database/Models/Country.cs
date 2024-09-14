using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class Country {
        
        [Key]
        public int Id { get; set; }
        
        // Navigation Properties
        public List<CountryTranslation> Translations { get; set; } = [];

    }
    
}
