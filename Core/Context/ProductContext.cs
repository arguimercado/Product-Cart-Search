using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Context
{
    public class ProductContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCart> ProductCarts { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            

        }


    }
}
