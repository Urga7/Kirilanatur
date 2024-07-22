using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Models {
    
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Product> Sandals { get; set; }
        public DbSet<ProductImage> SandalImages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Discount).HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
        
    }
    
}