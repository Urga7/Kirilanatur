using Kirilanatur.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.DbModels {
    
    public class SeedData {
        
        public static void Initialise(IServiceProvider serviceProvider) {
            
            var context = new KirilanaturDbContext(serviceProvider.GetRequiredService<DbContextOptions<KirilanaturDbContext>>());
            if (context.Products.Any())
                return;

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
            }).ToList();

            context.VariationOptions.AddRange(colorOptions);
            context.SaveChanges();

            var sizeOptions = Enumerable.Range(30, 16)
            .Select(size => new VariationOption {
                Value = size.ToString(),
                VariationId = sizeVariation.Id
            }).ToList();
            
            context.VariationOptions.AddRange(sizeOptions);
            context.SaveChanges();
            
            Product[] products = [
                new Product {
                    Name = "Sandal_142",
                    Description = "Mrežast sandal z gumbi",
                    Price = 10800,
                    Discount = 0,
                    Available = true,
                    CategoryId = sandalCategory.Id
                },
                new Product {
                    Name = "Sandal_143",
                    Description = "Zaprt sandal z vrvico",
                    Price = 10800,
                    Discount = 0,
                    Available = true,
                    CategoryId = sandalCategory.Id
                },
                new Product {
                    Name = "Sandal_144",
                    Description = "Egipčanski sandal",
                    Price = 10800,
                    Discount = 10,
                    Available = true,
                    CategoryId = sandalCategory.Id
                },
                new Product {
                    Name = "Sandal_145",
                    Description = "Zeleno usnje",
                    Price = 10800,
                    Discount = 0,
                    Available = true,
                    CategoryId = sandalCategory.Id
                },
            ];
            
            context.Products.AddRange(products);
            context.SaveChanges();

            ProductImage[] productImages_142 = [
                new ProductImage {
                    ImageUrl = "assets/images/products/art-142-01.jpg",
                    ImageDescription = "Sandal 142 default view",
                    ProductId = products[0].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-142-02.jpg",
                    ImageDescription = "Sandal 142 side view",
                    ProductId = products[0].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-142-03.jpg",
                    ImageDescription = "Sandal 142 example",
                    ProductId = products[0].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-142-04.jpg",
                    ImageDescription = "Sandal 142 top view",
                    ProductId = products[0].Id
                },
            ];
            
            ProductImage[] productImages_143 = [
                new ProductImage {
                    ImageUrl = "assets/images/products/art-143-01.jpg",
                    ImageDescription = "Sandal 143 default view",
                    ProductId = products[1].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-143-02.jpg",
                    ImageDescription = "Sandal 143 side view",
                    ProductId = products[1].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-143-03.jpg",
                    ImageDescription = "Sandal 143 example",
                    ProductId = products[1].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-143-04.jpg",
                    ImageDescription = "Sandal 143 top view",
                    ProductId = products[1].Id
                },
            ];
            
            ProductImage[] productImages_144 = [
                new ProductImage {
                    ImageUrl = "assets/images/products/art-143-01.jpg",
                    ImageDescription = "Sandal 144 default view",
                    ProductId = products[2].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-144-02.jpg",
                    ImageDescription = "Sandal 144 side view",
                    ProductId = products[2].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-144-03.jpg",
                    ImageDescription = "Sandal 144 example",
                    ProductId = products[2].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-144-04.jpg",
                    ImageDescription = "Sandal 144 top view",
                    ProductId = products[2].Id
                },
            ];
            
            ProductImage[] productImages_145 = [
                new ProductImage {
                    ImageUrl = "assets/images/products/art-145-01.jpg",
                    ImageDescription = "Sandal 145 default view",
                    ProductId = products[3].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-145-02.jpg",
                    ImageDescription = "Sandal 145 side view",
                    ProductId = products[3].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-145-03.jpg",
                    ImageDescription = "Sandal 145 example",
                    ProductId = products[3].Id
                },
                new ProductImage {
                    ImageUrl = "assets/images/products/art-145-04.jpg",
                    ImageDescription = "Sandal 145 top view",
                    ProductId = products[3].Id
                },
            ];
            
            context.ProductImages.AddRange(productImages_142);
            context.ProductImages.AddRange(productImages_143);
            context.ProductImages.AddRange(productImages_144);
            context.ProductImages.AddRange(productImages_145);
            context.SaveChanges();

        }
        
        public static void ClearTables(KirilanaturDbContext context) {
            context.Products.RemoveRange(context.Products);
            context.ProductImages.RemoveRange(context.ProductImages);
            context.ProductCategories.RemoveRange(context.ProductCategories);
            context.ProductConfigurations.RemoveRange(context.ProductConfigurations);
            context.ProductItems.RemoveRange(context.ProductItems);
            context.Variations.RemoveRange(context.Variations);
            context.VariationOptions.RemoveRange(context.VariationOptions);
            context.SaveChanges();
        }
        
    }
    
}
