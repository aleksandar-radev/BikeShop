using BikeShop.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Def", CreatedDate = DateTime.Now, Product = { } }
            );

            //Seed(modelBuilder);

        }

        //public DbSet<Order> Order { get; set; }
        //public DbSet<Brand> Brand { get; set; }

        //private void Seed(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Brand>().HasData(
        //        new Brand { Id = 1, Name = "Def", CreatedDate = DateTime.Now, Product = { } }
        //    );
        //}
    }
}