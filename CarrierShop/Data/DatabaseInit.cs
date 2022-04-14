using CarrierShop.Models;
using Microsoft.AspNetCore.Identity;

namespace CarrierShop.Data
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
            SeedAdmin();
            SeedUsers();
            SeedServices();
            SeedOrders();
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

                }, "Admin123!").GetAwaiter().GetResult();
                ApplicationUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@example.com");
                _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
        }
        private void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("User").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }
            if (_userManager.Users.Count() == 1)
            {
                for (int i = 1; i < 10; i++)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = $"user{i}@example.com",
                        Email = $"user{i}@example.com",
                    };
                    _userManager.CreateAsync(user, "Admin123!").GetAwaiter().GetResult();
                    _userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();
                }
            }
        }

        private void SeedServices()
        {
            if (_db.Services.Count() == 0)
            {
                List<Service> services = new List<Service>
                {
                    new Service("Доставка до адрес") { MaxKg = 20, PricePerKg = 3, PricePerKm = 5},
                    new Service("Доставка до офис") { MaxKg = 50, PricePerKg = 2, PricePerKm = 5},
                    new Service("Интернационална доставка") { MaxKg = 100, PricePerKg = 5, PricePerKm = 5}
                };
                _db.AddRange(services);
                _db.SaveChanges();
            }
        }
        private void SeedOrders()
        {
            if (_db.Orders.Count() == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    Random random = new Random();
                    int usersCount = _userManager.Users.Count();
                    int servicesCount = _db.Services.Count();
                    ApplicationUser customer = _userManager.Users.Skip(random.Next(0, usersCount)).First();
                    Service service = _db.Services.Skip(random.Next(0, servicesCount)).First();
                    Order order = new Order
                    {
                        CreatedDate = DateTime.Now,
                        Customer = customer,
                        Service = service,
                        Address = "Адрес" + i,
                        Kg = random.Next(1, 20),
                        ParcelDescription = "описание" + i
                    };
                    _db.Add(order);
                    _db.SaveChanges();
                }
            }
        }
    }
}
