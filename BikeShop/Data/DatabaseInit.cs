using BikeShop.Models;
using Microsoft.AspNetCore.Identity;

namespace BikeShop.Data
{
    public class DatabaseInit
    {
        public UserManager<ApplicationUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        public ApplicationDbContext _db;
        public DatabaseInit(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = applicationDbContext;
        }

        public void SeedDb()
        {
            IdentityRole role = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            _roleManager.CreateAsync(role).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser { UserName = "admin2@example.com" };
            _userManager.AddToRoleAsync(admin, "Admin");
            //Brand brand = new Brand { Name = "ade" };
            //this._db.Add(brand);
            //_db.SaveChanges();
        }

        private void SeedAdmin()
        {
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    
                }, "Admin123*").GetAwaiter().GetResult();
            }
        }
        private void SeedUsers()
        {

        }
    }
}
