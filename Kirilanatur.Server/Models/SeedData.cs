using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Models {
    
    public class SeedData {

        // TODO: Add a script to clear the tables
        public static void Initialise(IServiceProvider serviceProvider) {
            
            var context = new KirilanaturDbContext(serviceProvider.GetRequiredService<DbContextOptions<KirilanaturDbContext>>());
            //if (context.Products.Any())
            //    return;

            var sandalCategory = new ProductCategory {
                CategoryName = "Sandal"
            };

            context.ProductCategories.AddRange(sandalCategory);
            context.SaveChanges();

            var colorVariation = new Variation {
                Name = "Color",
                CategoryId = sandalCategory.Id
            };

            var sizeVariation = new Variation {
                Name = "Size",
                CategoryId = sandalCategory.Id
            };

            context.Variations.AddRange(colorVariation, sizeVariation);
            context.SaveChanges();

            string[] colors = [
                "White",
                "Black",
                "Blue",
                "Red",
                "Green",
                "Gray",
                "Yellow",
                "Brown",
            ];
            
            var colorOptions = colors.Select(color => new VariationOption {
                Value = color,
                VariationId = colorVariation.Id
            })
            .ToList();

            context.VariationOptions.AddRange(colorOptions);
            context.SaveChanges();

            var sizeOptions = new List<VariationOption>();
            for (int size = 30; size <= 45; ++size) {
                sizeOptions.Add(new VariationOption {
                    Value = size.ToString(),
                    VariationId = sizeVariation.Id
                });
            }
            
            context.VariationOptions.AddRange(sizeOptions);
            context.SaveChanges();

        }
        
    }
    
}
