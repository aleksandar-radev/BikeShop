using BikeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed(modelBuilder);

        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<BikeShop.Models.Product> Product { get; set; }
        public DbSet<IdentityRole> Role { get; set; }

        private void Seed(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            //SeedUsers(this._userManager);

            //Brand brand = new Brand { Id = 1, Name = "Def", CreatedDate = DateTime.Now };
            //modelBuilder.Entity<Brand>().HasData(
            //    brand
            //);

            //List<Product> products = new List<Product> {
            //    new Product { Id = 1, BrandId = brand.Id},
            //    new Product {Id = 2, BrandId = 1 }
            //};
            //modelBuilder.Entity<Product>().HasData(
            //    products
            //);
        }
        //private void SeedUsers(UserManager<ApplicationUser> userManager)
        //{
        //    if (userManager.FindByEmailAsync("admin@example.com").Result == null)
        //    {
        //        ApplicationUser user = new ApplicationUser
        //        {
        //            UserName = "admin@example.com",
        //            Email = "admin@example.com"

        //        };
        //        IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

        //        if (result.Succeeded)
        //        {
        //            userManager.AddToRoleAsync(user, "Admin").Wait();
        //        }
        //    }
        //}
    }
}