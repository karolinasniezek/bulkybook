using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Sucategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one-to-one relationship
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Subcategory)
                .WithOne(c => c.Category)
                .HasForeignKey<Subcategory>(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired();

            // one-to-many relationship
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithOne(t => t.Product);

            // many-to-many relationship
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
             .HasOne(pc => pc.Category)
             .WithMany(c => c.ProductCategories)
             .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
