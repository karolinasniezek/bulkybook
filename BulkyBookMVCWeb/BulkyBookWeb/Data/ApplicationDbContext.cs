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
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Subcategory)
                .WithOne(c => c.Category)
                .HasForeignKey<Subcategory>(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired();

        }
    }
}
