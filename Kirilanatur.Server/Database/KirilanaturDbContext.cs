using Kirilanatur.Server.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Database {
    
    public class KirilanaturDbContext : IdentityDbContext<User> {

        public KirilanaturDbContext(DbContextOptions<KirilanaturDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductImageTranslation> ProductImageTranslations { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategoryTranslation> ProductCategoryTranslations { get; set; }
        public DbSet<ProductConfiguration> ProductConfigurations { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<VariationTranslation> VariationTranslations { get; set; }
        public DbSet<VariationOption> VariationOptions { get; set; }
        public DbSet<VariationOptionTranslation> VariationOptionTranslations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ProductTranslation>()
            .HasOne(pt => pt.Product)
            .WithMany(p => p.Translations)
            .HasForeignKey(pt => pt.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.ParentCategory)
            .WithMany(pc => pc.ChildrenCategories)
            .HasForeignKey(pc => pc.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ProductCategoryTranslation>()
            .HasOne(pct => pct.ProductCategory)
            .WithMany(pc => pc.Translations)
            .HasForeignKey(pct => pct.ProductCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ProductConfiguration>()
            .HasKey(pc => new {
                pc.ProductItemId, 
                pc.VariationOptionId
            });

            modelBuilder.Entity<ProductConfiguration>()
            .HasOne(pc => pc.ProductItem)
            .WithMany(pi => pi.ProductConfigurations)
            .HasForeignKey(pc => pc.ProductItemId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductConfiguration>()
            .HasOne(pc => pc.VariationOption)
            .WithMany(vo => vo.ProductConfigurations)
            .HasForeignKey(pc => pc.VariationOptionId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductImage>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ProductImageTranslation>()
            .HasOne(pim => pim.ProductImage)
            .WithMany(pi => pi.Translations)
            .HasForeignKey(pim => pim.ProductImageId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductItem>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductItems)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Variation>()
            .HasOne(v => v.Category)
            .WithMany(c => c.Variations)
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<VariationTranslation>()
            .HasOne(vt => vt.Variation)
            .WithMany(v => v.Translations)
            .HasForeignKey(vt => vt.VariationId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VariationOption>()
            .HasOne(vo => vo.Variation)
            .WithMany(v => v.Options)
            .HasForeignKey(vo => vo.VariationId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<VariationOptionTranslation>()
            .HasOne(vot => vot.VariationOption)
            .WithMany(vo => vo.Translations)
            .HasForeignKey(vot => vot.VariationOptionId)
            .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
    
}