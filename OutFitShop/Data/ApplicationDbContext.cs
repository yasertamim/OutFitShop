using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OutFitShop.Models;

namespace OutFitShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne(b => b.OrderLine)
                .WithOne(i => i.Product)
                .HasForeignKey<OrderLine>(b => b.ProductId);
        }

        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderLine>? OrderLines { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }

    }
}