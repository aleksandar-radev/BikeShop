using CarPartsShop.Data;
using CarPartsShop.Models;
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
            SeedParts();
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

        private void SeedParts()
        {
            if (_db.Parts.Count() == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    Random rand = new Random();
                    int size = rand.Next(0, 14);
                    Part part = new Part
                    {
                        Name = "име на част" + i,
                        Description = "описание " + i,
                        Stock = rand.Next(0, 500),
                        PhotoUrl = "part" + i + ".jpg",
                        Price = rand.Next(500, 2000),
                        CreatedDate = DateTime.Now
                    };

                    _db.Add(part);
                    _db.SaveChanges();
                }
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
                    ApplicationUser buyer = _userManager.Users.Skip(random.Next(0, usersCount)).First();
                    Order order = new Order { CreatedDate = DateTime.Now, Buyer = buyer};
                    _db.Add(order);
                    _db.SaveChanges();
                    int q = random.Next(1, 3);
                    for (int j = 0; j < q; j++)
                    {
                        Part part = _db.Parts.Skip(random.Next(0, 5)).First();
                        OrderPart orderPart = new OrderPart { OrderId = order.Id, PartId = part.Id, Quantity = random.Next(1, 3) };
                        _db.Add(orderPart);
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
