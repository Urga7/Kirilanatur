using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Models {
    
    public class SeedData {

        public static void Initialise(IServiceProvider serviceProvider) {
            
            var context = new KirilanaturDbContext(serviceProvider.GetRequiredService<DbContextOptions<KirilanaturDbContext>>());
            //if (context.Products.Any())
            //    return;

            var sandalCategory = new ProductCategory { CategoryName = "Sandal" };
            context.ProductCategories.AddRange(sandalCategory);
            context.SaveChanges();
            
        }
        
    }
    
}
