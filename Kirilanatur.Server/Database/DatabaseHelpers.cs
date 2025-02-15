using Kirilanatur.Server.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Database {
    
    public class DatabaseHelpers {
        
        public static void Initialise(IServiceProvider serviceProvider) {
            
            var context = new KirilanaturDbContext(serviceProvider.GetRequiredService<DbContextOptions<KirilanaturDbContext>>());
            if (context.products.Any())
                return;
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////

            var sandalCategory = new ProductCategory();
            context.ProductCategories.AddRange(sandalCategory);
            context.SaveChanges();
            
            var sandalCategoryTranslationEn = new ProductCategoryTranslation {
                LanguageCode = "en",
                Name = "Sandal",
                ProductCategoryId = sandalCategory.Id
            };
            
            var sandalCategoryTranslationSl = new ProductCategoryTranslation {
                LanguageCode = "sl",
                Name = "Sandal",
                ProductCategoryId = sandalCategory.Id
            };
            
            context.ProductCategoryTranslations.AddRange(sandalCategoryTranslationEn, sandalCategoryTranslationSl);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////

            var colorVariation = new Variation {
                CategoryId = sandalCategory.Id
            };

            var sizeVariation = new Variation {
                CategoryId = sandalCategory.Id
            };

            context.Variations.AddRange(colorVariation, sizeVariation);
            context.SaveChanges();
            
            var colorVariationEn = new VariationTranslation {
                LanguageCode = "en",
                Name = "Color",
                VariationId = colorVariation.Id
            };
            
            var colorVariationSl = new VariationTranslation {
                LanguageCode = "sl",
                Name = "Barva",
                VariationId = colorVariation.Id
            };
            
            var sizeVariationEn = new VariationTranslation {
                LanguageCode = "en",
                Name = "Size",
                VariationId = sizeVariation.Id
            };
            
            var sizeVariationSl = new VariationTranslation {
                LanguageCode = "sl",
                Name = "Velikost",
                VariationId = sizeVariation.Id
            };
            
            context.VariationTranslations.AddRange(colorVariationEn, colorVariationSl, sizeVariationEn, sizeVariationSl);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            
            var colors = new List<(string En, string Sl)> {
                ("White", "Bela"),
                ("Black", "Črna"),
                ("Blue", "Modra"),
                ("Red", "Rdeča"),
                ("Green", "Zelena"),
                ("Gray", "Siva"),
                ("Yellow", "Rumena"),
                ("Brown", "Rjava")
            };
            
            foreach (var (enColor, slColor) in colors) {
                var colorOption = new VariationOption {
                    VariationId = colorVariation.Id
                };

                context.VariationOptions.Add(colorOption);
                context.SaveChanges();
                
                var colorOptionEn = new VariationOptionTranslation {
                    LanguageCode = "en",
                    Value = enColor,
                    VariationOptionId = colorOption.Id
                };

                var colorOptionSl = new VariationOptionTranslation {
                    LanguageCode = "sl",
                    Value = slColor,
                    VariationOptionId = colorOption.Id
                };

                context.VariationOptionTranslations.AddRange(colorOptionEn, colorOptionSl);
            }
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            
            var sizeOptionTranslations = new List<VariationOptionTranslation>();
            for (int size = 30; size < 46; ++size) {
                var sizeOption = new VariationOption {
                    VariationId = sizeVariation.Id
                };
                
                context.VariationOptions.Add(sizeOption);
                context.SaveChanges();
                
                sizeOptionTranslations.Add(new VariationOptionTranslation {
                    LanguageCode = "en",
                    Value = size.ToString(),
                    VariationOptionId = sizeOption.Id
                });
                
                sizeOptionTranslations.Add(new VariationOptionTranslation {
                    LanguageCode = "sl",
                    Value = size.ToString(),
                    VariationOptionId = sizeOption.Id
                });
            }

            context.VariationOptionTranslations.AddRange(sizeOptionTranslations);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////

            Product sandal142 = AddProductWithTranslations(context, new Product {
                Price = 10800,
                Discount = 0,
                Available = true,
                CategoryId = sandalCategory.Id
            }, new List<(string, string, string)> {
                ("en", "Sandal_142", "Webbed sandal with buttons"),
                ("sl", "Sandal_142", "Mrežast sandal z gumbi")
            });
            
            Product sandal143 = AddProductWithTranslations(context, new Product {
                Price = 10800,
                Discount = 0,
                Available = true,
                CategoryId = sandalCategory.Id
            }, new List<(string, string, string)> {
                ("en", "Sandal_143", "Closed sandal with a string"),
                ("sl", "Sandal_143", "Zaprt sandal z vrvico")
            });
            
            Product sandal144 = AddProductWithTranslations(context, new Product {
                Price = 10800,
                Discount = 0,
                Available = true,
                CategoryId = sandalCategory.Id
            }, new List<(string, string, string)> {
                ("en", "Sandal_144", "Egyptian sandal"),
                ("sl", "Sandal_144", "Egipčanski sandal")
            });
            
            Product sandal145 = AddProductWithTranslations(context, new Product {
                Price = 10800,
                Discount = 0,
                Available = true,
                CategoryId = sandalCategory.Id
            }, new List<(string, string, string)> {
                ("en", "Sandal_145", "Green leather"),
                ("sl", "Sandal_145", "Zeleno usnje")
            });

            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            
            AddProductImageWithTranslations(context, sandal142.Id, "assets/images/products-old/art-142-01.jpg", 
            [
                ("en", "Sandal 142 default view"),
                ("sl", "Sandal 142 privzet pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal142.Id, "assets/images/products-old/art-142-02.jpg", 
            [
                ("en", "Sandal 142 side view"),
                ("sl", "Sandal 142 stranski pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal142.Id, "assets/images/products-old/art-142-03.jpg", 
            [
                ("en", "Sandal 142 example"),
                ("sl", "Sandal 142 primer")
            ]);
            
            AddProductImageWithTranslations(context, sandal142.Id, "assets/images/products-old/art-142-04.jpg", 
            [
                ("en", "Sandal 142 top view"),
                ("sl", "Sandal 142 zgornji pogled")
            ]);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            
            AddProductImageWithTranslations(context, sandal143.Id, "assets/images/products-old/art-143-01.jpg", 
            [
                ("en", "Sandal 143 default view"),
                ("sl", "Sandal 143 privzet pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal143.Id, "assets/images/products-old/art-143-02.jpg", 
            [
                ("en", "Sandal 143 side view"),
                ("sl", "Sandal 143 stranski pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal143.Id, "assets/images/products-old/art-143-03.jpg", 
            [
                ("en", "Sandal 143 example"),
                ("sl", "Sandal 143 primer")
            ]);
            
            AddProductImageWithTranslations(context, sandal143.Id, "assets/images/products-old/art-143-04.jpg", 
            [
                ("en", "Sandal 143 top view"),
                ("sl", "Sandal 143 zgornji pogled")
            ]);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            
            AddProductImageWithTranslations(context, sandal144.Id, "assets/images/products-old/art-144-01.jpg", 
            [
                ("en", "Sandal 144 default view"),
                ("sl", "Sandal 144 privzet pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal144.Id, "assets/images/products-old/art-144-02.jpg", 
            [
                ("en", "Sandal 144 side view"),
                ("sl", "Sandal 144 stranski pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal144.Id, "assets/images/products-old/art-144-03.jpg", 
            [
                ("en", "Sandal 144 example"),
                ("sl", "Sandal 144 primer")
            ]);
            
            AddProductImageWithTranslations(context, sandal144.Id, "assets/images/products-old/art-144-04.jpg", 
            [
                ("en", "Sandal 144 top view"),
                ("sl", "Sandal 144 zgornji pogled")
            ]);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            
            AddProductImageWithTranslations(context, sandal145.Id, "assets/images/products-old/art-145-01.jpg", 
            [
                ("en", "Sandal 145 default view"),
                ("sl", "Sandal 145 privzet pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal145.Id, "assets/images/products-old/art-145-02.jpg", 
            [
                ("en", "Sandal 145 side view"),
                ("sl", "Sandal 145 stranski pogled")
            ]);
            
            AddProductImageWithTranslations(context, sandal145.Id, "assets/images/products-old/art-145-03.jpg", 
            [
                ("en", "Sandal 145 example"),
                ("sl", "Sandal 145 primer")
            ]);
            
            AddProductImageWithTranslations(context, sandal145.Id, "assets/images/products-old/art-145-04.jpg", 
            [
                ("en", "Sandal 145 top view"),
                ("sl", "Sandal 145 zgornji pogled")
            ]);
            
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////

            context.SaveChanges();
        }
        
        public static void ClearTables(KirilanaturDbContext context) {
            context.products.RemoveRange(context.products);
            context.ProductTranslations.RemoveRange(context.ProductTranslations);
            context.ProductImages.RemoveRange(context.ProductImages);
            context.ProductImageTranslations.RemoveRange(context.ProductImageTranslations);
            context.ProductCategoryTranslations.RemoveRange(context.ProductCategoryTranslations);
            context.ProductConfigurations.RemoveRange(context.ProductConfigurations);
            context.ProductItems.RemoveRange(context.ProductItems);
            context.Variations.RemoveRange(context.Variations);
            context.VariationTranslations.RemoveRange(context.VariationTranslations);
            context.VariationOptions.RemoveRange(context.VariationOptions);
            context.VariationOptionTranslations.RemoveRange(context.VariationOptionTranslations);
            context.SaveChanges();
        }
        
        private static Product AddProductWithTranslations(KirilanaturDbContext context, Product product, List<(string langCode, string name, string description)> translations) {
            context.products.Add(product);
            context.SaveChanges();
            var productTranslations = translations.Select(t => new ProductTranslation {
                LanguageCode = t.langCode,
                Name = t.name,
                Description = t.description,
                ProductId = product.Id
            }).ToList();

            context.ProductTranslations.AddRange(productTranslations);
            return product;
        }
        
        private static void AddProductImageWithTranslations(KirilanaturDbContext context, int productId, string imageUrl, (string, string)[] imageTranslations) {
            ProductImage image = new ProductImage {
                ImageUrl = imageUrl,
                ProductId = productId,
            };
            
            context.ProductImages.Add(image);
            context.SaveChanges();
            foreach (var (languageCode, description) in imageTranslations) {
                ProductImageTranslation translation = new ProductImageTranslation {
                    LanguageCode = languageCode,
                    Description = description,
                    ProductImageId = image.Id
                };
                
                context.ProductImageTranslations.Add(translation);
            }
        }
        
    }
    
}
