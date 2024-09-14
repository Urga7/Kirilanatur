using System.ComponentModel.DataAnnotations;

namespace Kirilanatur.Server.Database.Models {
    
    public class ProductCategory {

        [Key]
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }
        
        // Navigation Properties
        public ProductCategory? ParentCategory { get; set; }

        public List<ProductCategory> ChildrenCategories { get; set; } = [];

        public List<Product> Products { get; set; } = [];

        public List<Variation> Variations { get; set; } = [];
        
        public List<ProductCategoryTranslation> Translations { get; set; } = [];

    }
    
}
