using FoodSupplementShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodSupplementShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
    }
}