using Kirilanatur.Server.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Database;

public class KirilanaturDbContext : IdentityDbContext<KirilanaturUser> {

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
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentMethodTranslation> PaymentMethodTranslations { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
    public DbSet<ShippingMethodTranslation> ShippingMethodTranslations { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryTranslation> CountryTranslations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<KirilanaturUser> KirilanaturUsers { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<ShopOrder> ShopOrders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }


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

        modelBuilder.Entity<PaymentMethodTranslation>()
        .HasOne(pmt => pmt.PaymentMethod)
        .WithMany(pm => pm.Translations)
        .HasForeignKey(pmt => pmt.PaymentMethodId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShippingMethodTranslation>()
        .HasOne(smt => smt.ShippingMethod)
        .WithMany(sm => sm.Translations)
        .HasForeignKey(smt => smt.ShippingMethodId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CountryTranslation>()
        .HasOne(ct => ct.Country)
        .WithMany(c => c.Translations)
        .HasForeignKey(ct => ct.CountryId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Address>()
        .HasOne(a => a.Country)
        .WithMany(c => c.Addresses)
        .HasForeignKey(a => a.CountryId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<KirilanaturUser>()
        .HasOne(u => u.Address)
        .WithMany(a => a.Users)
        .HasForeignKey(u => u.AddressId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShoppingCartItem>()
        .HasOne(sci => sci.User)
        .WithMany(u => u.ShoppingCartItems)
        .HasForeignKey(sci => sci.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShoppingCartItem>()
        .HasOne(sci => sci.ProductItem)
        .WithMany(pi => pi.ShoppingCartItems)
        .HasForeignKey(sci => sci.ProductItemId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShopOrder>()
        .HasOne(so => so.User)
        .WithMany(u => u.ShopOrders)
        .HasForeignKey(so => so.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShopOrder>()
        .HasOne(so => so.ShippingMethod)
        .WithMany(sm => sm.ShopOrders)
        .HasForeignKey(so => so.ShippingMethodId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShopOrder>()
        .HasOne(so => so.PaymentMethod)
        .WithMany(pm => pm.ShopOrders)
        .HasForeignKey(so => so.PaymentMethodId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShopOrder>()
        .HasOne(so => so.OrderStatus)
        .WithMany(os => os.ShopOrders)
        .HasForeignKey(so => so.StatusId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderLine>()
        .HasOne(ol => ol.ShopOrder)
        .WithMany(os => os.OrderLines)
        .HasForeignKey(ol => ol.ShopOrderId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderLine>()
        .HasOne(ol => ol.ProductItem)
        .WithMany(pi => pi.OrderLines)
        .HasForeignKey(ol => ol.ProductItemId)
        .OnDelete(DeleteBehavior.Restrict);
    }

}
